// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using SharpDX;

namespace SharpDX.MediaFoundation
{
    public partial class Transform
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.MediaFoundation.Transform"/> class.
        /// </summary>
        /// <param name="guid">Guid of the Media Foundation Transform.</param>
        public Transform(Guid guid)
        {
            Utilities.CreateComInstance(guid, Utilities.CLSCTX.ClsctxInprocServer, Utilities.GetGuidFromType(typeof(Transform)), this);
        }

        /// <summary>
        /// Gets the stream identifiers for the input and output streams on this Media Foundation transform (MFT).
        /// </summary>
        /// <param name="dwInputIDsRef">An array allocated by the caller. The method fills the array with the input stream identifiers. The array size must be at least equal to the number of input streams. To get the number of input streams, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamCount" /></strong>.<para>If the caller passes an array that is larger than the number of input streams, the MFT must not write values into the extra array entries.</para></param>
        /// <param name="dwOutputIDsRef">An array allocated by the caller. The method fills the array with the output stream identifiers. The array size must be at least equal to the number of output streams. To get the number of output streams, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamCount" /></strong>.<para>If the caller passes an array that is larger than the number of output streams, the MFT must not write values into the extra array entries.</para></param>
        /// <returns><c>true</c> if Both streams IDs for input and output are valid, <c>false</c> otherwise</returns>
        /// <msdn-id>ms693988</msdn-id>
        /// <unmanaged>HRESULT IMFTransform::GetStreamIDs([In] unsigned int dwInputIDArraySize,[Out, Buffer] unsigned int* pdwInputIDs,[In] unsigned int dwOutputIDArraySize,[Out, Buffer] unsigned int* pdwOutputIDs)</unmanaged>
        /// <unmanaged-short>IMFTransform::GetStreamIDs</unmanaged-short>
        public bool TryGetStreamIDs(int[] dwInputIDsRef, int[] dwOutputIDsRef)
        {
            bool isStreamIDsValid = true;
            var result = GetStreamIDs_(dwInputIDsRef.Length, dwInputIDsRef, dwOutputIDsRef.Length, dwOutputIDsRef);

            //if not implemented
            if (result == Result.NotImplemented)
            {
                isStreamIDsValid = false;
            }
            else
            {
                result.CheckError();
            }

            return isStreamIDsValid;
        }

        /// <summary>
        /// Gets an available media type for an output stream on this Media Foundation transform (MFT).
        /// </summary>
        /// <param name="dwOutputStreamID">Output stream identifier. To get the list of stream identifiers, call <strong><see cref="SharpDX.MediaFoundation.Transform.GetStreamIDs" /></strong>.</param>
        /// <param name="dwTypeIndex">Index of the media type to retrieve. Media types are indexed from zero and returned in approximate order of preference.</param>
        /// <param name="typeOut">Receives a pointer to the <strong><see cref="SharpDX.MediaFoundation.MediaType" /></strong> interface. The caller must release the interface.</param>
        /// <returns><c>true</c> if A media type for an output stream is available, <c>false</c> otherwise</returns>
        /// <msdn-id>ms703812</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::GetOutputAvailableType([In] unsigned int dwOutputStreamID,[In] unsigned int dwTypeIndex,[Out] IMFMediaType** ppType)</unmanaged>	
        /// <unmanaged-short>IMFTransform::GetOutputAvailableType</unmanaged-short>	
        public bool TryGetOutputAvailableType(int dwOutputStreamID, int dwTypeIndex, out MediaType typeOut)
        {
            bool mediaTypeAvailable = true;
            var result = GetOutputAvailableType_(dwOutputStreamID, dwTypeIndex, out typeOut);

            //An object ran out of media types
            if (result == ResultCode.NoMoreTypes)
            {
                mediaTypeAvailable = false;
            }
            else
            {
                result.CheckError();
            }

            return mediaTypeAvailable;
        }

        /// <summary>
        /// Generates output from the current input data.
        /// </summary>
        /// <param name="dwFlags">Bitwise OR of zero or more flags from the <strong><see cref="SharpDX.MediaFoundation.TransformProcessOutputFlags" /></strong> enumeration.</param>
        /// <param name="outputSamplesRef">Pointer to an array of <strong><see cref="SharpDX.MediaFoundation.TOutputDataBuffer" /></strong> structures, allocated by the caller. The MFT uses this array to return output data to the caller.</param>
        /// <param name="dwStatusRef">Receives a bitwise OR of zero or more flags from the <strong><see cref="SharpDX.MediaFoundation.TransformProcessOutputStatus" /></strong> enumeration.</param>
        /// <returns><c>true</c> if the transform cannot produce output data until it receives more input data, <c>false</c> otherwise</returns>
        /// <msdn-id>ms704014</msdn-id>	
        /// <unmanaged>HRESULT IMFTransform::ProcessOutput([In] _MFT_PROCESS_OUTPUT_FLAGS dwFlags,[In] unsigned int cOutputBufferCount,[In] MFT_OUTPUT_DATA_BUFFER* pOutputSamples,[Out] _MFT_PROCESS_OUTPUT_STATUS* pdwStatus)</unmanaged>	
        /// <unmanaged-short>IMFTransform::ProcessOutput</unmanaged-short>	
        public bool ProcessOutput(TransformProcessOutputFlags dwFlags, TransformOutputDataBuffer[] outputSamplesRef, out TransformProcessOutputStatus dwStatusRef)
        {
            bool needMoreInput = false;
            var result = ProcessOutput_(dwFlags, outputSamplesRef.Length, ref outputSamplesRef[0], out dwStatusRef);

            // Check if it needs more input
            if (result == ResultCode.TransformNeedMoreInput)
            {
                needMoreInput = true;
            }
            else
            {
                result.CheckError();
            }

            return !needMoreInput;
        }

        /// <summary>
        /// Returns the attributes of the Transform, if it supports attributes.
        /// </summary>
        /// <returns>The Transform's attributes, or <c>null</c> if it does not implement attributes.</returns>
        /// <unmanaged>HRESULT IMFTransform::GetAttributes([Out] IMFAttributes** pAttributes)</unmanaged>
        /// <unmanaged-short>IMFTransform::GetAttributes</unmanaged-short>
        public MediaAttributes Attributes
        {
            get
            {
                var result = GetAttributes_(out MediaAttributes attributes);
                if (result == Result.NotImplemented)
                    return null;
                result.CheckError();
                return attributes;
            }
        }

        public void ProcessMessage(TransformMessage message)
        {
            ProcessMessage_(message.Type, message.Param).CheckError();
        }

        public void GetStreamCount(out int inputStreams, out int outputStreams)
        {
            GetStreamCount_(out inputStreams, out outputStreams).CheckError();
        }

        public void GetStreamIDs(out int[] inputIDs, out int[] outputIDs)
        {
            Result result;
            int[] inputs = null, outputs = null;
            do 
            {
                GetStreamCount_(out int inputStreams, out int outputStreams).CheckError();
                inputs = new int[inputStreams];
                outputs = new int[outputStreams];
                result = GetStreamIDs_(inputStreams, inputs, outputStreams, outputs);
            } while (result == ResultCode.BufferTooSmall);

            if (result == Result.NotImplemented)
            {
                inputIDs = outputIDs = null;
                return;
            }
            else if (result != ResultCode.BufferTooSmall)
                result.CheckError();
            inputIDs = inputs;
            outputIDs = outputs;
        }

        public void GetStreamLimits(out int inputMinimum, out int inputMaximum, out int outputMinimum, out int outputMaximum)
        {
            GetStreamLimits_(out inputMinimum, out inputMaximum, out outputMinimum, out outputMaximum).CheckError();
        }

        public TransformInputStreamInfo GetInputStreamInfo(int inputStreamID)
        {
            GetInputStreamInfo_(inputStreamID, out TransformInputStreamInfo streamInfo).CheckError();
            return streamInfo;
        }

        public MediaAttributes GetInputStreamAttributes(int inputStreamID)
        {
            var result = GetInputStreamAttributes_(inputStreamID, out MediaAttributes attributes);
            if (result == Result.NotImplemented)
                return null;
            result.CheckError();
            return attributes;
        }

        public void DeleteInputStream(int inputStreamID)
        {
            DeleteInputStream_(inputStreamID).CheckError();
        }

        public void AddInputStreams(int[] streamIDs)
        {
            Result result;
            if (streamIDs == null) throw new ArgumentNullException(nameof(streamIDs));
            unsafe
            {
                fixed (int* pIds = streamIDs)
                {
                    result = AddInputStreams_(streamIDs.Length, pIds);
                }
            }
            result.CheckError();
        }

        public MediaType[] GetInputAvailableTypes(int inputStreamID)
        {
            Result result;
            int typeIndex = 0;
            var types = new List<MediaType>();

            do
            {
                result = GetInputAvailableType_(inputStreamID, typeIndex, out MediaType type);
                if (result.Success)
                    types.Add(type);
                typeIndex++;
            } while (result == Result.Ok);

            if (result == Result.NotImplemented)
                return null;

            if (result != ResultCode.NoMoreTypes)
                result.CheckError();
            
            return types.ToArray();
        }

        public void SetInputType(int inputStreamID, MediaType type)
        {
            SetInputType_(inputStreamID, type, TransformSetTypeFlags.None).CheckError();
        }

        public Result TestInputType(int inputStreamID, MediaType type)
        {
            return SetInputType_(inputStreamID, type, TransformSetTypeFlags.TestOnly);
        }

        public MediaType GetInputCurrentType(int inputStreamID)
        {
            var result = GetInputCurrentType_(inputStreamID, out MediaType type);
            if (result == ResultCode.TransformTypeNotSet)
                return null;
            result.CheckError();
            return type;
        }

        public TransformInputStatusFlags GetInputStatus(int inputStreamID)
        {
            GetInputStatus_(inputStreamID, out TransformInputStatusFlags flags).CheckError();
            return flags;
        }

        public bool ProcessInput(int inputStreamID, Sample sample)
        {
            var result = ProcessInput_(inputStreamID, sample, 0);
            if (result == ResultCode.NotAccepting)
                return false;
            result.CheckError();
            return true;
        }

        public void ProcessEvent(int inputStreamID, MediaEvent mediaEvent)
        {
            throw new NotImplementedException();
        }

        public TransformOutputStreamInfo GetOutputStreamInfo(int outputStreamID)
        {
            throw new NotImplementedException();
        }

        public MediaAttributes GetOutputStreamAttributes(int outputStreamID)
        {
            throw new NotImplementedException();
        }

        public void DeleteOutputStream(int outputStreamID)
        {
            throw new NotImplementedException();
        }

        public void AddOutputStreams(int[] streamIDs)
        {
            throw new NotImplementedException();
        }

        public MediaType[] GetOutputAvailableTypes(int outputStreamID)
        {
            throw new NotImplementedException();
        }

        public void SetOutputType(int outputStreamID, MediaType type)
        {
            throw new NotImplementedException();
        }

        public int TestOutputType(int outputStreamID, MediaType type)
        {
            throw new NotImplementedException();
        }

        public MediaType GetOutputCurrentType(int outputStreamID)
        {
            throw new NotImplementedException();
        }

        public TransformOutputStatusFlags GetOutputStatus(int outputStreamID)
        {
            throw new NotImplementedException();
        }
    }
}