using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {

	public static int level;
	public static int checkPoint;
	public static int score;
	public static int money;
	public static int furthestLevel;
	public static int healthLevel;
	public static float[] healthMultiplierPerLevel = {1.00f, 1.20f, 1.50f, 1.75f, 2.10f};
	public static int damageLevel;
	public static float[] damageMultiplierPerLevel = {1.00f, 1.15f, 1.35f, 1.60f, 1.88f};
	public static int speedLevel;
	public static float[] speedMultiplierPerLevel = {1.00f, 1.10f, 1.20f, 1.35f, 1.50f};
	public static int[] stars = new int[4];
	public static int[] scores = new int[4];	
	public static int[] starScore3 = {10000, 10000, 10000, 10000};
	public static int[] starScore2 = {5000, 5000, 5000, 5000};
	public static int difficulty;
	public static float[] difficultyMultiplier = {1.00f, 1.75f, 2.50f};

}
