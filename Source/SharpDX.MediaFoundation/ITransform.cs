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
        int MinimumInputStreams { get; }
        int MaxmumInputStreams { get; }
        int NumInputStreams { get; }
        int[] InputStreamIDs { get; }
        TransformInputStreamInfo GetInputStreamInfo(int inputStreamID);
        MediaAttributes GetInputStreamAttributes(int inputStreamID);
        void DeleteInputStream(int inputStreamID);
        void AddInputStreams(int[] streamIDs);
        MediaType[] GetInputAvailableTypes(int inputStreamID);
        void SetInputType(int inputStreamID, MediaType type);
        int TestInputType(int inputStreamID, MediaType type);
        MediaType GetInputCurrentType(int inputStreamID);
        TransformInputStatusFlags GetInputStatus(int inputStreamID);
        void ProcessInput(int inputStreamID, Sample sample);
        void ProcessEvent(int inputStreamID, MediaEvent mediaEvent);

        int MinimumOutputStreams { get; }
        int MaxmumOutputStreams { get; }
        int NumOutputStreams { get; }
        int[] OutputStreamIDs { get; }
        TransformOutputStreamInfo GetOutputStreamInfo(int outputStreamID);
        MediaAttributes GetOutputStreamAttributes(int outputStreamID);
        void DeleteOutputStream(int outputStreamID);
        void AddOutputStreams(int[] streamIDs);
        MediaType[] GetOutputAvailableTypes(int outputStreamID);
        void SetOutputType(int outputStreamID, MediaType type);
        int TestOutputType(int outputStreamID, MediaType type);
        MediaType GetOutputCurrentType(int outputStreamID);
        TransformOutputStatusFlags GetOutputStatus(int outputStreamID);
        TransformProcessOutputStatus ProcessOutput(TransformProcessOutputFlags flags, TransformOutputDataBuffer[] outputSamples);
        
        MediaAttributes Attributes { get; }
        void ProcessMessage(TransformMessage message);
    }
}
