namespace LocalRandomNumberGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Security.Cryptography;

    class Program
    {
        private const int RandomNumberForSeed = 5034;
        private const int RandomNumberOfTimesToRandomise = 562;
        private const int RandomNumberOfTimesToDoIntensiveTask = 430210;
        private const string StringToHashForIntensiveTask = "Yeast cakes are the oldest and are very similar to yeast breads. Such cakes are often very traditional in form, and include such pastries as babka and stollen.";

        static void Main(string[] args)
        {
            long randomNumberResult = args.Length;
            
            var startTime = DateTime.Now.Ticks;

            randomNumberResult += MakeSureNotTooLarge(startTime);

            randomNumberResult += GetRandomNumberWithSeed(randomNumberResult);
            randomNumberResult += GetRandomNumberWithSeed(RandomNumberForSeed);
            randomNumberResult += GetRandomNumberWithoutSeed();

            for (int i = 0; i < RandomNumberOfTimesToRandomise; i++)
            {
                var addOrSubtractRandom = GetRandomNumberWithoutSeed();

                if (addOrSubtractRandom < (int.MaxValue / 2))
                {
                    randomNumberResult += GetRandomNumberWithoutSeed();
                }
                else
                {
                    randomNumberResult -= GetRandomNumberWithoutSeed();
                }
            }

            if (randomNumberResult < 0)
                randomNumberResult = -randomNumberResult;

            randomNumberResult += GetSizeOfRandomFileOnCDrive();

            for (int i = 0; i < RandomNumberOfTimesToRandomise - 5; i++)
            {
                randomNumberResult += GetRandomGuidNumbers();
            }

            randomNumberResult += GetPcNameAsNumbers();
            randomNumberResult -= Environment.ProcessorCount;
            randomNumberResult += Environment.OSVersion.Version.Build;
            randomNumberResult -= GetSpeedOfCpuIntensiveTask();

            if (randomNumberResult < 0)
                randomNumberResult = -randomNumberResult;

            var endTime = DateTime.Now.Ticks;
            randomNumberResult -= (endTime - startTime);

            var resultAsInteger = MakeSureNotTooLarge(randomNumberResult);
            
            Console.WriteLine(resultAsInteger.ToString());
            Console.ReadLine();
        }

        private static int MakeSureNotTooLarge(long largeNumber)
        {
            do
            {
                largeNumber = largeNumber / 10;
            }
            while (largeNumber > int.MaxValue);

            return Convert.ToInt32(largeNumber);
        }

        private static long GetRandomNumberWithoutSeed()
        {
            var random = new Random();
            return random.Next();
        }

        private static long GetRandomNumberWithSeed(long seed)
        {
            var seedAsInteger = MakeSureNotTooLarge(seed);

            var random = new Random(seedAsInteger);
            return random.Next();
        }

        private static long GetSizeOfRandomFileOnCDrive()
        {
            try
            {
                var fileNames = Directory.GetFiles("c:\\");

                if (fileNames != null && fileNames.Length > 0)
                {
                    var random = new Random();
                    var file = fileNames[random.Next(fileNames.Length)];
                    
                    var fi = new FileInfo(file);
                    return fi.Length;
                }
            }
            catch
            {
                
            }

            return 4322;
        }

        private static long GetRandomGuidNumbers()
        {
            long returnVal = 0;

            var bytes = Guid.NewGuid().ToByteArray();

            foreach (var currentByte in bytes)
            {
                returnVal += Convert.ToInt64(currentByte);
            }

            return returnVal;
        }

        private static long GetPcNameAsNumbers()
        {
            long returnVal = 0;

            var nameChars = Environment.MachineName.ToCharArray();

            for(int i = 0; i < nameChars.Length; i++)
            {
                returnVal += Convert.ToInt64(nameChars[i]);
            }

            for (int i = nameChars.Length - 1; i >= 0; i--)
            {
                returnVal += Convert.ToInt64(nameChars[i]);
            }

            return returnVal;
        }

        private static long GetCurrentDirectoryAsNumbers()
        {
            long returnVal = 0;

            var dirChars = Environment.CurrentDirectory.ToCharArray();

            for (int i = 0; i < dirChars.Length; i++)
            {
                returnVal += Convert.ToInt64(dirChars[i]);
            }

            return returnVal;
        }

        private static long GetSpeedOfCpuIntensiveTask()
        {
            var beforeTime = DateTime.Now.Ticks;

            for (int i = 0; i < RandomNumberOfTimesToDoIntensiveTask; i++)
            {
                var hashStringBytes = Encoding.UTF8.GetBytes(StringToHashForIntensiveTask);
                var hashAlgorithm = new SHA512Managed();
                hashAlgorithm.ComputeHash(hashStringBytes);
            }

            var bedTime = DateTime.Now.Ticks;
            return bedTime - beforeTime;
        }
    }
}
