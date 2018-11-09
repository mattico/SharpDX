using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;

namespace SharpDX.MediaFoundation
{
    public class TransformMessage
    {
        public TransformMessageType Type { get; }
        internal readonly IntPtr Param;

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
                DXGIDeviceManager dxgiManager;
                if ((dxgiManager = ComObject.QueryInterfaceOrNull<DXGIDeviceManager>(param)) != null)
                    return new TransformSetD3DManagerMessage(dxgiManager);
#if DESKTOP_APP
                Direct3DDeviceManager d3dManager;
                if ((d3dManager = ComObject.QueryInterfaceOrNull<SharpDX.MediaFoundation.DirectX.Direct3DDeviceManager>(param)) != null)
                    return new TransformSetD3DManagerMessage(d3dManager);
#endif
                goto default;
            case TransformMessageType.NotifyEndOfStream:
                return new TransformNotifyEndOfStreamMessage(param.ToInt32());
            case TransformMessageType.CommandMarker:
                return new TransformCommandMarkerMessage(param);
            default:
                return new TransformMessage(type, param);
            }
        }
    }

    public class TransformSetD3DManagerMessage : TransformMessage
    {
        public ComObject D3DManager => new ComObject(Param);

#if DESKTOP_APP
        public TransformSetD3DManagerMessage(SharpDX.MediaFoundation.DirectX.Direct3DDeviceManager d3dManager)
            : base(TransformMessageType.SetD3DManager, d3dManager.NativePointer)
        {
        } 
#endif

        public TransformSetD3DManagerMessage(DXGIDeviceManager d3dManager)
            : base(TransformMessageType.SetD3DManager, d3dManager.NativePointer)
        {
        }
    }

    public class TransformNotifyEndOfStreamMessage : TransformMessage
    {
        public int InputStreamID => Param.ToInt32();

        public TransformNotifyEndOfStreamMessage(int inputStreamID)
            : base(TransformMessageType.NotifyEndOfStream, (IntPtr)inputStreamID)
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
