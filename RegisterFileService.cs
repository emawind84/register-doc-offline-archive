using System;

namespace pmis
{
    public class RegisterFileService
    {

        public static void OpenRegisterFile(RegisterFile file)
        {
            try
            {
                System.Diagnostics.Process.Start(String.Format(@"{0}", file.FilePath));
            }
            catch (Exception e) {
                e.Log();
                throw e;
            }
        }

        public static void OpenRegisterFileLocation(RegisterFile file)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, " + file.FilePath);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

    }
}
