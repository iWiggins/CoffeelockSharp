using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeelockSharp.Models
{
    internal class Constants
    {
        public static readonly Indexer2<int> SLOTS_PER_SORCERER_LEVEL = new Indexer2<int>(new int[,]
        {
            { 2, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 3, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 3, 2, 0, 0, 0, 0, 0, 0 },
            { 4, 3, 3, 0, 0, 0, 0, 0, 0 },
            { 4, 3, 3, 1, 0, 0, 0, 0, 0 },
            { 4, 3, 3, 2, 0, 0, 0, 0, 0 },
            { 4, 3, 3, 3, 1, 0, 0, 0, 0 },
            { 4, 3, 3, 3, 2, 0, 0, 0, 0 },
            { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
            { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
            { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
            { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
            { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
            { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
            { 4, 3, 3, 3, 2, 1, 1, 1, 1 },
            { 4, 3, 3, 3, 3, 1, 1, 1, 1 },
            { 4, 3, 3, 3, 3, 2, 1, 1, 1 },
            { 4, 3, 3, 3, 3, 2, 2, 1, 1 }
        });

        public static readonly Indexer<int> PACT_LEVELS_PER_WARLOCK_LEVEL = new Indexer<int>(new int[]
        {
            1,
            1,
            2,
            2,
            3,
            3,
            4,
            4,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5
        });

        public static readonly Indexer<int> PACT_SLOTS_PER_WARLOCK_LEVEL = new Indexer<int>(new int[]
        {
            1,
            2,
            2,
            2,
            2,
            2,
            2,
            2,
            2,
            2,
            3,
            3,
            3,
            3,
            3,
            3,
            4,
            4,
            4,
            4
        });

        public static readonly Indexer<int> SLOT_POINT_COST = new Indexer<int>(new int[]
        {
            2,
            3,
            5,
            6,
            7
        });

        public static readonly Indexer<int> POINTS_PER_SLOT = new Indexer<int>(new int[]
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9
        });

        public static readonly Indexer<int> POINTS_PER_SORCERER_LEVEL = new Indexer<int>(new int[]
        {
            0,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20
        });

        public static readonly Indexer<string> SLOT_LABELS = new Indexer<string>(new string[]
        {
            "1st",
            "2nd",
            "3rd",
            "4th",
            "5th",
            "6th",
            "7th",
            "8th",
            "9th"
        });
    }
}
