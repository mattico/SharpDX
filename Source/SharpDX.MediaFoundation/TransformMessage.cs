using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.MediaFoundation.DirectX;

namespace SharpDX.MediaFoundation
{
    public class TransformMessage
    {
        public TransformMessageType Type { get; }
        protected readonly IntPtr Param;

        protected TransformMessage(TransformMessageType type, IntPtr param)
        {
            Type = type;
            Param = param;
        }

        public TransformMessage Create(TransformMessageType type, IntPtr param)
        {
            switch (type)
            {
            case TransformMessageType.SetD3DManager:
                DXGIDeviceManager mgr;
                if ((mgr = ComObject.QueryInterfaceOrNull<DXGIDeviceManager>(param)) != null)
                    return new TransformSetD3DManagerMessage(mgr);
#if DESKTOP_APP
                Direct3DDeviceManager mgr;
                else if ((mgr = ComObject.QueryInterfaceOrNull<Direct3DDeviceManager>(param)) != null)
                    return new TransformSetD3DManagerMessage(mgr);
#endif
                else return new TransformMessage(type, IntPtr.Zero);
            case TransformMessageType.NotifyEndOfStream:
                return new TransformNotifyEndOfStreamMessage(param.ToInt32());
            case TransformMessageType.CommandMarker:
                return new TransformCommandMarkerMessage(param);
            default:
                return new TranformMessage(type, IntPtr.Zero);
            }
        }
    }

    public class TransformSetD3DManagerMessage : TransformMessage
    {
        public ComObject D3DManager => new ComObject(Param);

#if DESKTOP_APP
        public TransformSetD3DManagerMessage(Direct3DDeviceManager d3dManager)
            : base(TransformMessageType.SetD3DManager, d3dManager)
        {
        } 
#endif

        public TransformSetD3DManagerMessage(DXGIDeviceManager d3dManager)
            : base(TransformMessageType.SetD3DManager, d3dManager)
        {
        }
    }

    public class TransformNotifyEndOfStreamMessage : TransformMessage
    {
        public int InputStreamID => Param.ToInt32();

        public TransformNotifyEndOfStreamMessage(int inputStreamID)
            : base(TransformMessageType.NotifyEndOfStream, inputStreamID)
        {
        }
    }

    public class TransformCommandMarkerMessage : TransformMessage
    {
        public IntPtr MarkerContext => Param;

        public TransformCommandMarkerMessage(IntPtr markerContext)
            : base(TransformMessageType.CommandMarker, markerContext)
        {
        }
    }
}
