using CSharpProd.HelloWorld;

namespace CSharpProd
{
    using System;

    public class SolutionMerge {

        private static bool UseIndex1(int[] nums1, int m, int[] nums2, int n, int nums1Index, int nums2Index)
        {
            bool useNum1 = false;
            if (nums1Index == m)
                return false;
            if (nums2Index == n)
                return true;
            if (nums1[nums1Index] <= nums2[nums2Index])
            {
                return true;
            }

            return false;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n) {
            var temp = new int[m + n];
            var nums1Index = 0;
            var nums2Index = 0;
            for (int i = 0; i < m + n; i++)
            {
                var useNum1 = UseIndex1(nums1, m, nums2, n, nums1Index, nums2Index);


                /// nums1Index < m && nums2Index < n && nums1[nums1Index] <= nums2[nums2Index]
                //if (nums1Index < m && )


                if (useNum1)
                {
                    temp[i] = nums1[nums1Index];
                    nums1Index++;
                }
                else
                {
                    temp[i] = nums2[nums2Index];
                    nums2Index++;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                nums1[i] = temp[i];
            }
        }
    }

    public class Solution {
        public int CalculateLongest(int[] nums, int i, int k)
        {
            int currentLength = 0;
            int zerosLeft = k;
            int currentIndex = i;
            while (currentIndex < nums.Length)
            {

                if (nums[currentIndex] == 1)
                {
                    currentLength+=1;
                    currentIndex++;
                }
                else
                {
                    if (zerosLeft < 0)
                        break;
                    currentLength+=1;
                    currentIndex ++;
                    zerosLeft -= 1;


                }
            }
            return currentLength;
        }
        public int LongestOnes(int[] nums, int k) {
            int maxMax = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var currentMax = CalculateLongest(nums, i, k);
                Console.WriteLine($"{i} {k} {currentMax} {maxMax}");
                maxMax = Math.Max(currentMax, maxMax);
            }
            return maxMax;

        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            //DataFeed.DataFeedTest.Run();

            //TestMerge();

            var input = new int[] {0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1};
            var s = new Solution().LongestOnes(input, 3);
            Console.WriteLine(s);

            //HelloWorldExample.Run();
            //HelloWorld.CustomSettingsExample.Run();

            //HttpTests.SimpleHttpTest.Run();
            //HttpTests.AdvancedHttpTest.Run();
            //HttpTests.AdvancedHttpWithConfig.Run();
            //HttpTests.TracingHttp.Run();

            //Logging.ElasticSearchLogging.Run();

            //MongoDb.MongoDbTest.Run();

            //RealtimeReporting.InfluxDbReporting.Run();
        }

        private static void TestMerge()
        {
            var input1 = new int[] {1, 2, 3, 0, 0, 0};
            var input2 = new int[] {2, 5, 6};
            var input3 = new int[] {2, 5, 6, 0, 0, 0};
            var input4 = new int[] {1, 2, 3,};

            var input5 = new int[] {2, 2, 2, 3, 5, 6, 0, 0, 0, 0, 0};
            var input6 = new int[] {1, 2, 3, 9, 10};

            Console.WriteLine("Test 1");
            new SolutionMerge().Merge(input3, 3, input4, 3);
            foreach (var item in input3)
                Console.WriteLine(item);
            Console.WriteLine("Test 2");
            new SolutionMerge().Merge(input5, 6, input6, 5);
            foreach (var item in input5)
                Console.WriteLine(item);
        }
    }
}
