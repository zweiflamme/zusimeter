using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ZusiMeter
{
    public static class CurrentTrainLength
    {
        /// <summary>
        /// Returns the length (in m) of the currently running train.
        /// 
        /// Any exceptions thrown while reading the train length are passed on.
        /// </summary>
        /// <returns>the length (in m) of the currently running train</returns>
        public static double GetCurrentTrainLength()
        {
            // Retrieve Zusi base dir
            var zusiDir = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Zusi", "ZusiDir", null);

            if (zusiDir == null)
            {
                throw new Exception("Error reading Zusi base dir from Registry");
            }

            // Retrieve Temp\aktuellerzug.txt file
            StreamReader fileStreamReader;
            fileStreamReader = new StreamReader(Path.Combine((string)zusiDir, @"Temp\aktuellerzug.txt"));

            // Read lengths of locos/wagons in Temp\aktuellerzug.txt
            string locoOrWagonFileName;
            double totalLength = 0;
            StreamReader locoOrWagonReader;
            while ((locoOrWagonFileName = fileStreamReader.ReadLine()) != null)
            {
                string fullLocoOrWagonPath = Path.Combine((string)zusiDir, (string)locoOrWagonFileName);
                string extension = Path.GetExtension(fullLocoOrWagonPath);
                locoOrWagonReader = new StreamReader(fullLocoOrWagonPath);

                if (extension.ToLower() == ".lok")
                {
                    totalLength += ReadLengthFromLoco(locoOrWagonReader);
                }
                else if (extension.ToLower() == ".wag")
                {
                    totalLength += ReadLengthFromWagon(locoOrWagonReader);
                }
            }

            return totalLength;
        }

        /// <summary>
        /// Reads the length of a locomotive from a .lok file.
        /// </summary>
        /// <param name="reader">A reader with the file.</param>
        /// <returns>The length of the locomotive in m.</returns>
        private static double ReadLengthFromLoco(StreamReader reader)
        {
            // Read until first #IF, then read the second line after that.
            // This is valid for all format versions (2.0, 2.2, 2.4) in the official repository.

            string line;
            do
            {
                line = reader.ReadLine();
            } while (line != null && line != "#IF");

            reader.ReadLine();
            line = reader.ReadLine().Replace(',', '.');

            double length;
            if (double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture, out length))
            {
                return length;
            }
            else
            {
                throw new FormatException("Line '" + line + "' is not a float value.");
            }
        }

        /// <summary>
        /// Reads the length of a wagon from a .wag file.
        /// </summary>
        /// <param name="reader">A reader with the file.</param>
        /// <returns>The length of the wagon in m.</returns>
        private static double ReadLengthFromWagon(StreamReader reader)
        {
            string line;

            // Read first two lines (version and author), then read until first # (end of free text)
            string version = reader.ReadLine();
            reader.ReadLine();

            do
            {
                line = reader.ReadLine();
            } while (line != null && line != "#");

            // Skip a number of lines after that, depending on the version
            int linesToSkip = 12;
            if (version == "1.1")
            {
                linesToSkip = 4;
            }

            Enumerable.Range(0, linesToSkip).Select(x => reader.ReadLine());

            line = reader.ReadLine().Replace(',', '.');

            double length;
            if (double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture, out length))
            {
                return length;
            }
            else
            {
                throw new FormatException("Line '" + line + "' is not a float value.");
            }
        }
    }
}
