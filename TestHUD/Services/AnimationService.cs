using TestHUD.Helpers;

namespace TestHUD.Services
{
    public class AnimationService
    {
        public event Action<double>? TargetModified;

        public bool IsAnimating { get; set; } = true;

        public async void StartAnimationAsync(double from, double to, double periodForward, double periodBack, 
                                              double targetCustomCompassPosition = 0)
        {
            double currentPosition = 0;
            while (IsAnimating)
            {
                // Forward
                double fromPosition = from;
                double toPosition = to;
                if (targetCustomCompassPosition != 0)
                {
                    fromPosition = AnimationHelper.Instance.CalculateAngle(currentPosition);
                    toPosition = toPosition + fromPosition;
                }
                currentPosition = await GenerateAnimation(amplitudeFrom: fromPosition, amplitudeTo: toPosition, period: periodForward);
                // Back
                fromPosition = to;
                toPosition = from;
                if (targetCustomCompassPosition != 0)
                {
                    fromPosition = AnimationHelper.Instance.CalculateAngle(currentPosition);
                    toPosition = targetCustomCompassPosition + fromPosition;
                }
                currentPosition = await GenerateAnimation(amplitudeFrom: fromPosition, amplitudeTo: toPosition, period: periodBack);
            }
        }

        private async Task<double> GenerateAnimation(double amplitudeFrom, double amplitudeTo, double period)
        {
            double time = 0;
            double deltaTime = 0.01;

            while (true)
            {
                // Наша синусоида должна быть смещена так, чтобы возвращать только положительное значение sineValue, соответствующее амплитуде и периоду.
                double sineWaveMinimumPosition = amplitudeFrom / 2;
                double sineWaveAmplitude = (amplitudeTo / 2) - sineWaveMinimumPosition; // Учитываем начальную позицию
                double sineWavePeriod = period * 2; // * 2 - для одного направления
                double sineWaveOffset = (amplitudeTo / 2) + sineWaveMinimumPosition; // Компенсируем дополнительный offset, вместе с начальной позицией
                double sineValue = GenerateSineWave(time, sineWaveAmplitude, sineWavePeriod) + sineWaveOffset;

                TargetModified?.Invoke(sineValue);

                //Debug.WriteLine("sineValue: " + sineValue);
                //Debug.WriteLine("period: " + period);
                //Debug.WriteLine("time: " + time);

                time += deltaTime;
                if (time >= period)
                {
                    double result = Math.Ceiling(sineValue);
                    return result;
                }
                await Task.Delay((int)(deltaTime * 1000));
            }
        }

        // y = A * sin(2 * π * x / T + φ)
        private double GenerateSineWave(double x, double amplitude, double period)
        {
            double initialPhase = -Math.Asin(1.0);
            double radianValue = 2 * Math.PI * x / period + initialPhase;
            double sineValue = amplitude * Math.Sin(radianValue);
            return sineValue;
        }
    }
}
