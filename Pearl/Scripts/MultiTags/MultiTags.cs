﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pearl.events;

namespace Pearl.multitags
{
    /// <summary>
    /// Multitags in a gameobject
    /// </summary>
    public class MultiTags : LogicalSimpleManager
    {
        #region Inspector Fields
        /// <summary>
        /// List of tags that the gameobject has.
        /// </summary>
        [SerializeField]
        private List<Tags> tags;
        #endregion

        #region Properties
        /// <summary>
        /// List of tags that the gameobject has.
        /// </summary>
        public List<Tags> ListTags { get { return tags; } }
        #endregion

        #region Unity CallBacks
        protected override void OnAwake()
        {
            if (tags == null)
                tags = new List<Tags>();

            if (tags.Count > 0)
            {
                EliminateDuplicate();
                tags.Sort();
            }

        }
        #endregion

        #region Private methods
        private void EliminateDuplicate()
        {
            tags.Sort();
            int index = 0;
            while (index < tags.Count - 1)
            {
                if (tags[index] == tags[index + 1])
                    tags.RemoveAt(index);
                else
                    index++;
            }
        }
        #endregion
    }
}
