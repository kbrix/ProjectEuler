﻿using System.Numerics;
using NUnit.Framework;

namespace SolutionTestsCS;

public class Problem66Tests
{
	[TestCase(2, "3", "2")]
	[TestCase(3, "2", "1")]
	[TestCase(5, "9", "4")]
	[TestCase(6, "5", "2")]
	[TestCase(7, "8", "3")]
	[TestCase(8, "3", "1")]
	[TestCase(10, "19", "6")]
	[TestCase(11, "10", "3")]
	[TestCase(12, "7", "2")]
	[TestCase(13, "649", "180")]
	[TestCase(14, "15", "4")]
	[TestCase(15, "4", "1")]
	[TestCase(17, "33", "8")]
	[TestCase(18, "17", "4")]
	[TestCase(19, "170", "39")]
	[TestCase(20, "9", "2")]
	[TestCase(21, "55", "12")]
	[TestCase(22, "197", "42")]
	[TestCase(23, "24", "5")]
	[TestCase(24, "5", "1")]
	[TestCase(26, "51", "10")]
	[TestCase(27, "26", "5")]
	[TestCase(28, "127", "24")]
	[TestCase(29, "9801", "1820")]
	[TestCase(30, "11", "2")]
	[TestCase(31, "1520", "273")]
	[TestCase(32, "17", "3")]
	[TestCase(33, "23", "4")]
	[TestCase(34, "35", "6")]
	[TestCase(35, "6", "1")]
	[TestCase(37, "73", "12")]
	[TestCase(38, "37", "6")]
	[TestCase(39, "25", "4")]
	[TestCase(40, "19", "3")]
	[TestCase(41, "2049", "320")]
	[TestCase(42, "13", "2")]
	[TestCase(43, "3482", "531")]
	[TestCase(44, "199", "30")]
	[TestCase(45, "161", "24")]
	[TestCase(46, "24335", "3588")]
	[TestCase(47, "48", "7")]
	[TestCase(48, "7", "1")]
	[TestCase(50, "99", "14")]
	[TestCase(51, "50", "7")]
	[TestCase(52, "649", "90")]
	[TestCase(53, "66249", "9100")]
	[TestCase(54, "485", "66")]
	[TestCase(55, "89", "12")]
	[TestCase(56, "15", "2")]
	[TestCase(57, "151", "20")]
	[TestCase(58, "19603", "2574")]
	[TestCase(59, "530", "69")]
	[TestCase(60, "31", "4")]
	[TestCase(61, "1766319049", "226153980")]
	[TestCase(62, "63", "8")]
	[TestCase(63, "8", "1")]
	[TestCase(65, "129", "16")]
	[TestCase(66, "65", "8")]
	[TestCase(67, "48842", "5967")]
	[TestCase(68, "33", "4")]
	[TestCase(69, "7775", "936")]
	[TestCase(70, "251", "30")]
	[TestCase(71, "3480", "413")]
	[TestCase(72, "17", "2")]
	[TestCase(73, "2281249", "267000")]
	[TestCase(74, "3699", "430")]
	[TestCase(75, "26", "3")]
	[TestCase(76, "57799", "6630")]
	[TestCase(77, "351", "40")]
	[TestCase(78, "53", "6")]
	[TestCase(79, "80", "9")]
	[TestCase(80, "9", "1")]
	[TestCase(82, "163", "18")]
	[TestCase(83, "82", "9")]
	[TestCase(84, "55", "6")]
	[TestCase(85, "285769", "30996")]
	[TestCase(86, "10405", "1122")]
	[TestCase(87, "28", "3")]
	[TestCase(88, "197", "21")]
	[TestCase(89, "500001", "53000")]
	[TestCase(90, "19", "2")]
	[TestCase(91, "1574", "165")]
	[TestCase(92, "1151", "120")]
	[TestCase(93, "12151", "1260")]
	[TestCase(94, "2143295", "221064")]
	[TestCase(95, "39", "4")]
	[TestCase(96, "49", "5")]
	[TestCase(97, "62809633", "6377352")]
	[TestCase(98, "99", "10")]
	[TestCase(99, "10", "1")]
	[TestCase(101, "201", "20")]
	[TestCase(102, "101", "10")]
	[TestCase(103, "227528", "22419")]
	[TestCase(104, "51", "5")]
	[TestCase(105, "41", "4")]
	[TestCase(106, "32080051", "3115890")]
	[TestCase(107, "962", "93")]
	[TestCase(108, "1351", "130")]
	[TestCase(109, "158070671986249", "15140424455100")]
	[TestCase(110, "21", "2")]
	[TestCase(111, "295", "28")]
	[TestCase(112, "127", "12")]
	[TestCase(113, "1204353", "113296")]
	[TestCase(114, "1025", "96")]
	[TestCase(115, "1126", "105")]
	[TestCase(116, "9801", "910")]
	[TestCase(117, "649", "60")]
	[TestCase(118, "306917", "28254")]
	[TestCase(119, "120", "11")]
	[TestCase(120, "11", "1")]
	[TestCase(122, "243", "22")]
	[TestCase(123, "122", "11")]
	[TestCase(124, "4620799", "414960")]
	[TestCase(125, "930249", "83204")]
	[TestCase(126, "449", "40")]
	[TestCase(127, "4730624", "419775")]
	[TestCase(128, "577", "51")]
	[TestCase(661, "16421658242965910275055840472270471049", "638728478116949861246791167518480580")]
    public static void FundamentalSolutionForPellsEquation_Test(int n, string x, string y)
    {
        var fundamentalSolution = SolutionCS.Problem66.FundamentalSolutionForPellsEquation(n);
        Assert.AreEqual(fundamentalSolution.x, BigInteger.Parse(x));
        Assert.AreEqual(fundamentalSolution.y, BigInteger.Parse(y));
    }
    
    [Test]
    public static void SolutionTest()
    {
        var solution = SolutionCS.Problem66.Solution();
        Assert.AreEqual(661, solution);
    }
}