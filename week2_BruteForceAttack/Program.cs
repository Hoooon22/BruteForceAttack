using System;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace week2_BruteForceAttack
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int pw_type; // 입력받은 패스워드의 유형
            int pw_length; // 입력받은 패스워드의 길이

            // 1. 무작위 패스워드 입력
            Console.WriteLine("0. 숫자, 1. 알파벳, 2. 숫자+알파벳, 3. 숫자+알파벳+특수문자");
            Console.Write("패스워드 유형을 선택하세요. :");
            pw_type = int.Parse(Console.ReadLine());
            Console.Write("패스워드의 길이를 설정하세요.(4~8) :");
            pw_length = int.Parse(Console.ReadLine());

            // 2. BruteForceAttack 실행 - 100회 반복
            BruteForceAttack(pw_type, pw_length, 100);
        }

        public static string Generate_Password(int type, int length)
        {
            Random rand = new Random();
            string password = "";
            char ch;
            Regex regex_numchar = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).{4,8}$"); // 적어도 숫자, 문자 하나씩 존재
            Regex regex_numcharspch = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\W]).{4,8}$"); // 적어도 숫자, 문자, 특수문자 하나씩 존재

            switch (type)
            {
                case 0: // 0. 숫자
                    for (int i = 0; i < length; i++)
                    {
                        password += rand.Next(0, 9).ToString();
                    }
                    break;
                case 1: // 1. 알파벳
                    for (int i = 0; i < length; i++)
                    {
                        // 알파벳이 아니면 반복
                        do
                        {
                            ch = Convert.ToChar(rand.Next(65, 122));
                        } while (ch > 90 && ch < 97);
                        password += ch.ToString();
                    }
                    break;
                case 2: // 2. 숫자+알파벳
                    while (true)
                    {
                        password = "";
                        for (int i = 0; i < length; i++)
                        {
                            do
                            {
                                ch = Convert.ToChar(rand.Next(48, 122));
                            } while ((ch > 57 && ch < 65) || (ch > 90 && ch < 97));
                            password += ch.ToString();
                        }
                        // 적어도 숫자와 알파벳이 하나씩 존재하는지
                        if (regex_numchar.IsMatch(password))
                        {
                            break;
                        }
                    }
                    break;
                case 3: // 3. 숫자+알파벳+특수문자
                    while (true)
                    {
                        password = "";
                        for (int i = 0; i < length; i++)
                        {
                            do
                            {
                                ch = Convert.ToChar(rand.Next(33, 126));
                            } while ((ch > 57 && ch < 65) || (ch > 90 && ch < 97));
                            password += ch.ToString();
                        }
                        // 적어도 숫자와 알파벳, 특수문자가 하나씩 존재하는지
                        if (regex_numcharspch.IsMatch(password))
                        {
                            break;
                        }
                    }
                    break;

                default:
                    break;
            }

            return password;
        }
        
        // str 문자열의 모든 패스워드 조합을 구함
        public static int CompareCombination(string password, string str, int timeComplex)
        {
            char[] key = new char[8]; // 생성한 모든 경우의 문자
            // 4자리
            for (int i = 0; i < str.Length; i++)
            {
                key[0] = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    key[1] = str[j];
                    for (int k = 0; k < str.Length; k++)
                    {
                        key[2] = str[k];
                        for (int a = 0; a < str.Length; a++)
                        {
                            key[3] = str[a];
                            timeComplex++;
                            if (string.Compare(password, new string(key)) == 0) // password와 key가 같을 경우 탈출
                            {
                                return timeComplex;
                            }
                        }
                    }
                }
            }
            // 5자리
            for (int i = 0; i < str.Length; i++)
            {
                key[0] = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    key[1] = str[j];
                    for (int k = 0; k < str.Length; k++)
                    {
                        key[2] = str[k];
                        for (int a = 0; a < str.Length; a++)
                        {
                            key[3] = str[a];
                            for (int b = 0; b < str.Length; b++)
                            {
                                key[4] = str[b];
                                timeComplex++;
                                if (string.Compare(password, new string(key)) == 0)
                                {
                                    return timeComplex;
                                }
                            }
                        }
                    }
                }
            }
            // 6자리
            for (int i = 0; i < str.Length; i++)
            {
                key[0] = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    key[1] = str[j];
                    for (int k = 0; k < str.Length; k++)
                    {
                        key[2] = str[k];
                        for (int a = 0; a < str.Length; a++)
                        {
                            key[3] = str[a];
                            for (int b = 0; b < str.Length; b++)
                            {
                                key[4] = str[b];
                                for (int c = 0; c < str.Length; c++)
                                {
                                    key[5] = str[c];
                                    timeComplex++;
                                    if (string.Compare(password, new string(key)) == 0)
                                    {
                                        return timeComplex;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // 7자리
            for (int i = 0; i < str.Length; i++)
            {
                key[0] = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    key[1] = str[j];
                    for (int k = 0; k < str.Length; k++)
                    {
                        key[2] = str[k];
                        for (int a = 0; a < str.Length; a++)
                        {
                            key[3] = str[a];
                            for (int b = 0; b < str.Length; b++)
                            {
                                key[4] = str[b];
                                for (int c = 0; c < str.Length; c++)
                                {
                                    key[5] = str[c];
                                    for (int d = 0; d < str.Length; d++)
                                    {
                                        key[6] = str[d];
                                        timeComplex++;
                                        if (string.Compare(password, new string(key)) == 0)
                                        {
                                            return timeComplex;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // 8자리
            for (int i = 0; i < str.Length; i++)
            {
                key[0] = str[i];
                for (int j = 0; j < str.Length; j++)
                {
                    key[1] = str[j];
                    for (int k = 0; k < str.Length; k++)
                    {
                        key[2] = str[k];
                        for (int a = 0; a < str.Length; a++)
                        {
                            key[3] = str[a];
                            for (int b = 0; b < str.Length; b++)
                            {
                                key[4] = str[b];
                                for (int c = 0; c < str.Length; c++)
                                {
                                    key[5] = str[c];
                                    for (int d = 0; d < str.Length; d++)
                                    {
                                        key[6] = str[d];
                                        for (int e = 0; e < str.Length; e++)
                                        {
                                            key[7] = str[e];
                                            timeComplex++;
                                            if (string.Compare(password, new string(key)) == 0)
                                            {
                                                return timeComplex;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return -1;
        }

        public static void BruteForceAttack(int type, int length, int repeat)
        {
            Stopwatch sw = new Stopwatch(); // real time 기록하는 타이머
            int timeComplex; // 시간복잡도
            double sumOfRealtime = 0; // 전체 테스트 타이머 합계 (msec)
            double sumOfTimeComplex = 0; // 전체 테스트 시간복잡도 합계
            string password; // 입력할 패스워드

            string allOfChar = ""; // 숫자, 알파벳, 특수문자가 모두 들어가있는 문자열
            for (int i = 33; i < 127; i++)
            {
                allOfChar += Convert.ToChar(i).ToString();
            }

            // 테스트는 100회 실시
            for (int i = 0; i < repeat; i++)
            {
                // 1. 패스워드 생성
                password = Generate_Password(type, length);

                // 2. BruteForceAttack (모든 유형과 자릿수)
                timeComplex = 0;
                sw.Reset();
                sw.Start();

                // 모든 자릿수 (4~8자리) 비교
                timeComplex = CompareCombination(password, allOfChar, timeComplex); // 모든 조합과 비교
            
                // 시간, 시간복잡도 저장
                sw.Stop();
                Console.WriteLine("테스트 " + i + "=> 복잡도 :" + timeComplex + ", 소요시간: " + sw.ElapsedMilliseconds * 0.001 + "(sec)");
                sumOfRealtime += sw.ElapsedMilliseconds;
                sumOfTimeComplex += timeComplex;
            }
            // 총 테스트 결과 출력
            Console.WriteLine("[[[자릿수 :" + length + ", 유형 :" + type + "의 테스트 결과]]]");
            Console.WriteLine("테스트 " + repeat + "회 평균 RealTime :" + (sumOfRealtime / repeat) * 0.001 + "(sec), 평균 시간복잡도 :" + sumOfTimeComplex / repeat);
        }

    }
}
