using System;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            Adachi adachi = new Adachi();
            Console.WriteLine(adachi.getDistanceTravelled(100));
        }

    }

    // 朝練版
    class Test
    {
        private const double _primaryForce = 0.5;
        private const double _secondaryForce = 0.7;
        private const double _mass = 0.3;
        private const int _delay = 1;

        double getDistanceTravelled(int time)
        {
            double result;
            result = getMoveDist(getFirstAcc(), getPrimaryTime(time));
            int secondaryTime = time - _delay;
            if(secondaryTime > 0)
            {
                double primaryVel = getFirstAcc() * _delay;
                result += primaryVel * secondaryTime + getMoveDist(getSecondAcc(), secondaryTime);
            }
            return result;
        }

        double getMoveDist(double acc, int time)
        {
            return 0.5 * acc * time * time;
        }

        int getPrimaryTime(int time)
        {
            return Math.Min(time, _delay);
        }

        double getSecondAcc()
        {
            return (_primaryForce + _secondaryForce) / _mass;
        }

        double getFirstAcc()
        {
            return _primaryForce / _mass;
        }
    }

    // 安達勉強用
    class Adachi
    {
        private const double _primaryForce = 0.5;
        private const double _secondaryForce = 0.7;
        private const double _mass = 0.3;
        private const int _delay = 1;

        // 問い合わせによる一時変数の置き換え
        // 説明用変数の導入
        // 一時変数の分離

        public double getDistanceTravelled(int time)
        {
            double firstMoveDist = 0.5 * getPrimaryAcc() * getPrimaryTime(time) * getPrimaryTime(time);
            double result = firstMoveDist;

            if (getSecondaryTime(time) > 0)
            {
                double secondMoveDist = getPrimaryVel() * getSecondaryTime(time) + 0.5 * getSecondaryAcc() * getSecondaryTime(time) * getSecondaryTime(time);
                result += secondMoveDist;
            }

            return result;
        }

        double getPrimaryVel()
        {
            return getPrimaryAcc() * _delay;
        }

        double getSecondaryAcc()
        {
            return (_primaryForce + _secondaryForce) / _mass;
        }

        int getSecondaryTime(int time)
        {
            return time - _delay;
        }

        double getPrimaryAcc()
        {
            return _primaryForce / _mass;
        }

        int getPrimaryTime(int time)
        {
            return Math.Min(time, _delay);
        }
    }
}
