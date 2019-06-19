using System;
using System.Collections.Generic;
using System.Text;

namespace KeepFaith
{
    public delegate void IntegerDelegate(int integerInput);
    public delegate void PatronDelegate(Patron patron);

    public class GameBoard
    {
        public IntegerDelegate OnLevelStart;
        public PatronDelegate OnPatronSeated;
        public PatronDelegate OnPatronActivated;
        public IntegerDelegate OnNewFaithTotal;
        public const int FAITH_PER_LEVEL_TO_ADVANCE = 100;
        public const int LEVEL_DURATION = 60;
        public const int MAX_LEVEL = 5;
        public int Faith { get; private set; }
        public int Level { get; private set; }
        public float ElapsedOnCurrentLevel { get; private set; }
        public Patron ActivePatron { get; private set; }
        public List<Patron> SeatedPatrons { get; private set; }

        private void Advance()
        {
            CheckWinConditions();
            CheckLoseConditions();
            AdvanceToNextLevel();
        }

        private void CheckWinConditions()
        {
            if (Level > MAX_LEVEL)
            {
                throw new Exception("WIN");
            }
        }

        private void CheckLoseConditions()
        {
            if (Faith < (FAITH_PER_LEVEL_TO_ADVANCE * Level))
            {
                throw new Exception("LOSE");
            }
        }

        private void AdvanceToNextLevel()
        {
            SeatedPatrons.Clear();
            AddFaith(Level * FAITH_PER_LEVEL_TO_ADVANCE);
            LevelUp();
            ActivateANewPatron();
        }

        private void LevelUp()
        {
            Level += 1;
            OnLevelStart?.Invoke(Level);
        }

        private void ActivateANewPatron()
        {
            ActivePatron = new Patron(new List<AilmentType> { AilmentType.ANGRY }, 25);
            OnPatronActivated?.Invoke(ActivePatron);
        }

        public void ElapseTime(float deltaTime)
        {
            ElapsedOnCurrentLevel += deltaTime;
            while (ElapsedOnCurrentLevel > LEVEL_DURATION)
            {
                ElapsedOnCurrentLevel -= LEVEL_DURATION;
                Advance();
            }
        }

        public bool ElapseWouldEndLevel(float deltaTime)
        {
            return deltaTime + ElapsedOnCurrentLevel > LEVEL_DURATION;
        }

        public void BestowBlessing(Blessing blessing)
        {
            ActivePatron.ReceiveBlessing(blessing);
            SeatedPatrons.Add(ActivePatron);
            OnPatronSeated?.Invoke(ActivePatron);
            ActivateANewPatron();
        }

        public void AddFaith(int faith)
        {
            Faith += faith;
            OnNewFaithTotal?.Invoke(Faith);
        }
    }
}
