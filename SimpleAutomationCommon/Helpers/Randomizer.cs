﻿using System;

namespace SimpleAutomationCommon.Helpers
{
    public static class Randomizer
    {
        private static readonly Random Random = new Random();

        public static int RandomId(int minRange = 0, int maxRange = 10000)
            => Random.Next(minRange, maxRange);

        public static int RandomInt(int minRange = 0, int maxRange = 10000)
            => Random.Next(minRange, maxRange);

        public static string RandomString(int length, int minRange = 0, int maxRange = 9)
        {
            string value = string.Empty;

            for (int i = 0; i < length; i++)
            {
                value += Random.Next(minRange, maxRange).ToString();
            }

            return value;
        }
    }
}