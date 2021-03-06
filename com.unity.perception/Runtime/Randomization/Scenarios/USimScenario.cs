﻿using System;
using Unity.Simulation;

namespace UnityEngine.Experimental.Perception.Randomization.Scenarios
{
    /// <summary>
    /// Defines a scenario that is compatible with the Run in USim window
    /// </summary>
    /// <typeparam name="T">The type of constants to serialize</typeparam>
    public abstract class USimScenario<T> : Scenario<T> where T : USimConstants, new()
    {
        /// <summary>
        /// Returns whether the entire scenario has completed
        /// </summary>
        public sealed override bool isScenarioComplete => currentIteration >= constants.totalIterations;

        /// <summary>
        /// Progresses the current scenario iteration
        /// </summary>
        protected sealed override void IncrementIteration()
        {
            currentIteration += constants.instanceCount;
        }

        /// <summary>
        /// Deserializes this scenario's constants from the USim AppParams Json file
        /// </summary>
        public sealed override void Deserialize()
        {
            if (Configuration.Instance.IsSimulationRunningInCloud())
                constants = Configuration.Instance.GetAppParams<T>();
            else
                base.Deserialize();
            currentIteration = constants.instanceIndex;
        }
    }

    /// <summary>
    /// A class encapsulating the scenario constants fields required for USim cloud execution
    /// </summary>
    [Serializable]
    public class USimConstants
    {
        /// <summary>
        /// The total number of iterations to run a scenario for
        /// </summary>
        public int totalIterations = 100;

        /// <summary>
        /// The number of USim instances assigned to executed this scenario
        /// </summary>
        public int instanceCount = 1;

        /// <summary>
        /// The USim instance index of the currently executing worker
        /// </summary>
        public int instanceIndex;
    }
}
