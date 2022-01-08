using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ASP.net_Aplication.Extends {
    public static class ExtIFormFile_IsImage {
        private const int imgMinBytes = 512;

        public static bool IsImage(this IFormFile file) {
            //check mime
            string type = file.ContentType.ToLower();
            if (type != "image/jpg" && type != "image/jpeg" && type != "image/pjpeg" &&
                type != "image/gif" && type != "image/x-png" && type != "image/png")
                return false;

            //check type
            string fileName = file.FileName;
            if (Path.GetExtension(fileName).ToLower() != ".jpg" && Path.GetExtension(fileName).ToLower() != ".png"
                && Path.GetExtension(fileName).ToLower() != ".gif" && Path.GetExtension(fileName).ToLower() != ".jpeg")
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
                byte[] buffer = new byte[imgMinBytes];
                file.OpenReadStream().Read(buffer, 0, imgMinBytes);
                string content = Encoding.UTF8.GetString(buffer);
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
