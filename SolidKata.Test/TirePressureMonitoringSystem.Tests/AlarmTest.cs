using System;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void AlarmTurnsOnWhenPressureIsTooLow()
        {
            // Arrange
            var alarm = new Alarm(new FakeSensor(14));

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void AlarmTurnsOnWhenPressureIsTooHigh()
        {
            // Arrange
            var alarm = new Alarm(new FakeSensor(50));

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void AlarmDoesNotTurnOnWhenPressureIsValid()
        {
            // Arrange
            var alarm = new Alarm(new FakeSensor(19));

            // Act
            alarm.Check();

            // Assert
            Assert.False(alarm.AlarmOn);
        }

    }

    internal class FakeSensor : ISensor
    {
        private int _fakeValue;

        public FakeSensor(int fakeValue)
        {
            this._fakeValue = fakeValue;
        }

        public double PopNextPressurePsiValue()
        {
            return _fakeValue;
        }
    }
}