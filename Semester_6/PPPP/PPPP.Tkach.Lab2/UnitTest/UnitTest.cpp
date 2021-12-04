#include "pch.h"
#include "CppUnitTest.h"
    
#include "../PPPP.Tkach.Lab2/Header.h"
#include "../PPPP.Tkach.Lab2/Source.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace UnitTest
{
    TEST_CLASS(UnitTest)
    {
    public:


        TEST_METHOD(AnyY_3)
        {
            // arrange
            double x = 4;
            // act and assert
            Assert::IsTrue(AnyY(x) == "3 4", L"Assert");
        }
        
        TEST_METHOD(Solve_3)
        {
            double a = 0;
            double b = 0;
            double c = 13;
            double d = 0;
            double e = 0;
            double f = 572;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "3 44", L"Assert");
        }

        TEST_METHOD(AnyX_4)
        {
            double y = 4;
            Assert::IsTrue(AnyX(y) == "4 4", L"Assert");
        }

        TEST_METHOD(Solve_4)
        {
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 5;
            double e = 0;
            double f = 5;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "4 1", L"Assert");
        }

        TEST_METHOD(EndlessAnswers_1)
        {

            double firstArg = -2;
            double secondArg = 1;
            double thirdArg = 3;

            Assert::IsTrue(EndlessAnswers(firstArg, secondArg, thirdArg) == "1 2 3", L"Assert");
        }

        //y = kx + n, b == 0 && e == 0  
        TEST_METHOD(Solve_1_1)
        {

            double a = 0;
            double b = 0;
            double c = 18;
            double d = 2;
            double e = 0;
            double f = 66;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "1 -9 33", L"Assert");
        }

        //y = kx + n, d == 0 && f == 0 
        TEST_METHOD(Solve_1_2)
        {

            double a = 3;
            double b = 9;
            double c = 0;
            double d = 0;
            double e = 54;
            double f = 0;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "1 -0 6", L"Assert");
        }

        //y = kx + n, a / b = c / d
        TEST_METHOD(Solve_1_3)
        {

            double a = 3;
            double b = 6;
            double c = 6;
            double d = 12;
            double e = 9;
            double f = 18;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "1 -1 2", L"Assert");
        }
        TEST_METHOD(Solve_AllZero_5)
        {

            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "5", L"Assert");
        }

        TEST_METHOD(Solve_OnlyAnswer_2_1)
        {

            double a = 4;
            double b = 1;
            double c = 4;
            double d = 5;
            double e = 9;
            double f = 29;
            std::string string = "";

            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "2 1 5", L"Assert");
        }

        TEST_METHOD(Solve_OnlyAnswer_2_2)
        {

            double a = 15;
            double b = 8;
            double c = 9;
            double d = 2;
            double e = 85;
            double f = 37;
            std::string string = "";

            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "2 3 5", L"Assert");
        }

        TEST_METHOD(Solve_noAnswer_0_1)
        {

            double a = 2;
            double b = 2;
            double c = 2;
            double d = 2;
            double e = 2;
            double f = 9;

            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "0", L"Assert");
        }

        TEST_METHOD(Solve_noAnswer_0_2)
        {

            double a = 0;
            double b = 1;
            double c = 0;
            double d = 2;
            double e = 1;
            double f = 1;

            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "0", L"Assert");
        }

        TEST_METHOD(Solve_ManyAnswers_1)
        {

            double a = 5;
            double b = 5;
            double c = 25;
            double d = 25;
            double e = 0;
            double f = 0;

            std::string string = "";
            Assert::IsTrue(Solve(a, b, c, d, e, f, string) == "1 -1 0", L"Assert");
        }
    };
}