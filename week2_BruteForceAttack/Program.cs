using System;

namespace week2_BruteForceAttack
{
    class MainClass
    {
        public static string Generate_Password(int type)
        {
            string password = "";

            switch (type)
            {
                case 0:


                default:
                    break;
            }

            return password;
        }

        public static void Main(string[] args)
        {
            string password; // 입력할 패스워드
            int pw_type; // 입력받은 패스워드의 유형
            int pw_length; // 입력받은 패스워드의 길이
            string key; // 생성한 모든 경우의 문

            // 1. 무작위 패스워드 입력
            System.Console.WriteLine("0. 숫자, 1. 알파벳, 2. 숫자+알파벳, 3. 숫자+알파벳+특수문자");
            System.Console.WriteLine("패스워드 유형을 선택하세요.");
            pw_type = int.Parse(Console.ReadLine());
            password = Generate_Password(pw_type);

            // 2. 
        }
    }
}
