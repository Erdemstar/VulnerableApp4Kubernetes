using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace VulnerableApp4Kubernetes.Helper
{
    public class GeneralHelper
    {

        public string RunCommand(string arguments)
        {
            var shellName = "/bin/bash";
            var argsPrepend = "-c ";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                shellName = @"C:\Windows\System32\cmd.exe";
                argsPrepend = "/c ";
            }
            
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = shellName,
                        Arguments = argsPrepend +  "\"" + arguments + "\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        
        public string ReadFile(string filename)
        {
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadToEnd();
                    return line;
                }
            }
            catch (Exception ex)
            {
                return "We didn't find file which you are looking for";
            }
           
        }
   
        public string DeleteFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    return "File is deleted";
                }
                else
                {
                    return "There is no file which you entered";
                }
            }
            catch (Exception ex)
            {
                return "There is an error while file delete process";
            }
        }

        public string uploadFile(IFormFile file)
        {
            string FileName = file.FileName;
            string FilePath = "./" + FileName;
            try
            {
                using (var localFile = File.OpenWrite(FilePath))
                using (var uploadedFile = file.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }
                return "File uploaded" + FilePath;
            }
            catch (Exception ex)
            {
                return "There is an error while file upload " + ex.ToString();
            }
        }

        public string GetRequest(string URL)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(URL).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                    else { return "There is an error while sending request"; }
                }
            }
            catch (Exception ex)
            {
                return "There is an error while sending request";
            }
            
        }

    }
}
