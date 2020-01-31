using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Service
{
    public static class TextEncoder
    {
        public static string Encode(this string Source, int Key = 1) => 
            new string(Source.Select(c => (char)(c + Key)).ToArray());

        public static string Decode(this string Source, int Key = 1) =>
            new string(Source.Select(c => (char)(c - Key)).ToArray());
    }
}
