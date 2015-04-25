﻿// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System.Drawing;
using System.Drawing.Imaging;
using CefSharp.Internals;

namespace CefSharp.OffScreen
{
    public class GdiBitmapInfo : BitmapInfo
    {
        private Bitmap bitmap;

        private bool createNewBitmap;

        public GdiBitmapInfo()
        {
            BytesPerPixel = 4;
        }

        public override bool CreateNewBitmap
        {
            get { return createNewBitmap; }
        }

        public override void ClearBitmap()
        {
            createNewBitmap = true;
        }

        public Bitmap CreateBitmap()
        {
            var stride = Width * BytesPerPixel;

            bitmap = new Bitmap(Width, Height, stride, PixelFormat.Format32bppPArgb, BackBufferHandle);

            createNewBitmap = false;

            return bitmap;
        }
    }
}
