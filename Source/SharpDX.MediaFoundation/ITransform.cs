// Copyright (c) 2018 SharpDX - Alexandre Mutel
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
using SharpDX;

namespace SharpDX.MediaFoundation
{
    [Shadow(typeof(TransformShadow))]
    public partial interface ITransform
    {
        Result GetStreamLimits(out int dwInputMinimumRef, out int dwInputMaximumRef, out int dwOutputMinimumRef, out int dwOutputMaximumRef);
        Result GetStreamCount(out int cInputStreamsRef, out int cOutputStreamsRef);
        Result GetStreamIDs(int dwInputIDArraySize, int[] dwInputIDsRef, int dwOutputIDArraySize, int[] dwOutputIDsRef);
        Result GetInputStreamInfo(int dwInputStreamID, out TInputStreamInformation streamInfoRef);
        Result GetOutputStreamInfo(int dwOutputStreamID, out TOutputStreamInformation streamInfoRef);
        Result GetAttributes(out MediaAttributes attributesRef);
        Result GetInputStreamAttributes(int dwInputStreamID, out MediaAttributes attributesRef);
        Result GetOutputStreamAttributes(int dwOutputStreamID, out MediaAttributes attributesRef);
        Result DeleteInputStream(int dwStreamID);
        Result AddInputStreams(int cStreams, int adwStreamIDs);
        Result GetInputAvailableType(int dwInputStreamID, int dwTypeIndex, out MediaType typeOut);
        Result GetOutputAvailableType(int dwOutputStreamID, int dwTypeIndex, out MediaType typeOut);
        Result SetInputType(int dwInputStreamID, MediaType typeRef, MftSetTypeFlags dwFlags);
        Result SetOutputType(int dwOutputStreamID, MediaType typeRef, MftSetTypeFlags dwFlags);
        Result GetInputCurrentType(int dwInputStreamID, out MediaType typeOut);
        Result GetOutputCurrentType(int dwOutputStreamID, out MediaType typeOut);
        Result GetInputStatus(int dwInputStreamID, out int dwFlagsRef);
        Result GetOutputStatus(out int dwFlagsRef);
        Result SetOutputBounds(long hnsLowerBound, long hnsUpperBound);
        Result ProcessEvent(int dwInputStreamID, MediaEvent eventRef);
        Result ProcessMessage(TMessageType eMessage, IntPtr ulParam);
        Result ProcessInput(int dwInputStreamID, Sample sampleRef, int dwFlags);
        Result ProcessOutput(TransformProcessOutputFlags dwFlags, int cOutputBufferCount, ref TOutputDataBuffer outputSamplesRef, out TransformProcessOutputStatus dwStatusRef);
    }
}
