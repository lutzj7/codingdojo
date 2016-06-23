using System;

namespace parrot
{
    public abstract class Parrot
    {
        protected const double BaseSpeed = 12.0;

        public abstract double GetSpeed();
    }

    public class EuropeanParrot : Parrot
    {
        public override double GetSpeed()
        {
            return BaseSpeed;            
        }
    }

    public class AfricanParrot : Parrot
    {
        readonly int _numberOfCoconuts;
        private const double LoadFactor = 9.0;

        public AfricanParrot(int numberOfCoconuts)
        {
            if (numberOfCoconuts < 0)
                throw new ArgumentException();
            _numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts); 
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        readonly bool _isNailed;
        readonly double _voltage;
        private const double MaxParrotSpeedUnderVoltage = 24.0;
        public override double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed(_voltage);
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(MaxParrotSpeedUnderVoltage, voltage * BaseSpeed);
        }

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            if (double.IsNaN((voltage)) || voltage < 0)
                throw new ArgumentException();
            _voltage = voltage;
            _isNailed = isNailed; 
        }
    }
}
