#region Copyright 
//
// Copyright (C) 2013-2018 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
#endregion // Copyright

using System;
using System.Text;
using System.Security.Cryptography; // for MD5

namespace GlueAPIIntro
{
    class Utils
  {
    ///===============================================================
    ///  Rutiones to generate the signature components. 
    ///  These are generic helper functions. Not specific to Glue API.
    ///  cf. https://b4.autodesk.com/api/doc/doc_api.shtml
    ///===============================================================

    /// UNIX Epoch timestamp - 
    /// the number of seconds since January 1st, 1970 00:00:00 GMT 
    /// (the UNIX epoch). 
    /// The BIM 360 Glue Platform accepts timestamps up to a configurable 
    /// number of minutes on either side of the server timestamp, 
    /// to accommodate reasonable clock drift
    /// 
    public static int GetUNIXEpochTimestamp()
    {
      TimeSpan tSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1));
      int timestamp = (int)tSpan.TotalSeconds;
      return timestamp;
    }

    /// Calculate a hash based on MD5 message-digest algorithm.
    /// 128-bit (16-byte) hash value, typically expressed as 32 digit
    /// hexadecimal number. 
    /// Here we use System.Securrity.Cryptogaphy.MD5 
    /// cf. http://en.wikipedia.org/wiki/MD5
    ///
    public static string ComputeMD5Hash(string aString)
    {
      // step 1, calculate MD5 hash from aString
      MD5 md5 = System.Security.Cryptography.MD5.Create();
      byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(aString);
      byte[] hash = md5.ComputeHash(inputBytes);

      // step 2, convert byte array to hex string
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
      {
        sb.Append(hash[i].ToString("x2"));
      }
      return sb.ToString();
    }

  }
}
