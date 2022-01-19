using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ASP.net_Aplication.Extends {
    public static class ExtIFormFile_IsImage {
        private const Int32 imgMinBytes = 512;

        public static Boolean IsImage(this IFormFile file) {
            if (file is null)
                return false;

            //check mime
            String type = file.ContentType.ToLower();
            if (type is not "image/jpg" and not "image/jpeg" and not "image/pjpeg" and not "image/gif" and not "image/x-png" and not "image/png")
                return false;

            //check type
            String fileName = file.FileName;
            if (Path.GetExtension(fileName).ToLower() is not ".jpg" and not ".png" and not ".gif" and not ".jpeg")
                return false;

            //first bytes
            try {
                //can read
                if (!file.OpenReadStream().CanRead)
                    return false;

                //have min size
                if (file.Length < imgMinBytes)
                    return false;

                //is image
                Byte[] buffer = new Byte[imgMinBytes];
                file.OpenReadStream().Read(buffer, 0, imgMinBytes);
                String content = Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                    return false;
            } catch {
                return false;
            }

            return true;
        }
    }
}
