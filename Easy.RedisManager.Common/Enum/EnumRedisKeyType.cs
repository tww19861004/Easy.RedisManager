﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Easy.RedisManager.Common.Enum
{
    /// <summary>
    /// The type of RedisKey
    /// </summary>
    public enum EnumRedisKeyType
    {
        /// <summary>
        /// None
        /// </summary>
        [Description("None")]
        None,
        /// <summary>
        /// String
        /// </summary>
        [Description("String")]
        String,
        /// <summary>
        /// List
        /// </summary>
        [Description("List")]
        List,
        /// <summary>
        /// Set
        /// </summary>
        [Description("Set")]
        Set,
        /// <summary>
        /// SortedSet
        /// </summary>
        [Description("SortedSet")]
        SortedSet,
        /// <summary>
        /// Hash
        /// </summary>
        [Description("Hash")]
        Hash,
    }
}
