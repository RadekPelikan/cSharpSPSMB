package cz.spsmb;

import java.util.Arrays;
import java.util.Scanner;

public class Main {


    public static void main(String[] args) {
        //printarg(args);

        double[] ans = calculateKvadraticFormula(1, 1, -2);
        if (ans.length == 0) {
            System.out.println("Nemá řešení");
        } else if (ans.length == 1) {
            System.out.println("x1: " + ans[0]);
        } else {
            System.out.println("x1: " + ans[0]);
            System.out.println("x2: " + ans[1]);
        }
    }

    static void name() {
        Scanner sc = new Scanner(System.in);
        System.out.print("jak se jmenujes? :");
        String name = sc.nextLine();
        System.out.print("tvoje jmeno je: " + name);
    }

    static void printarg(String[] args) {
        for (int i = 0; i < args.length; i++) {
            System.out.println(args[i]);
        }
    }

    static void printGrid() {
        int[][] bohata = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};

        for (int i = 0; i < bohata.length; i++) {

            for (int j = 0; j < 3; j++) {
                System.out.print(bohata[i][j]);
            }
            System.out.println();
        }
    }

    static void fizzbuzz(int n) {
        // cislo n delitelny 3, vypis fizz
        // cislo n delitelny 5, vypis buzz
        // cislo n delitelny 3 a 5, tak vypis fizz buzz
        // Jinak vypis n
        if (n % 3 == 0 & n % 5 == 0) {
            System.out.println("fizzbuzz");
        } else if (n % 5 == 0) {
            System.out.println("buzz");
        } else if (n % 3 == 0) {
            System.out.println("fizz");
        } else {
            System.out.println(n);
        }
    }

    static double[] calculateKvadraticFormula(double a, double b, double c) {
        double D = (b * b) - (4 * a * c);
        double x1 = (-b + Math.sqrt(D)) / (2 * a);
        double x2 = (-b - Math.sqrt(D)) / (2 * a);
        System.out.println(Math.sqrt(D));

        double[] result;
        if (D > 0) {
            result = new double[2];
            result[0] = x1;
            result[1] = x2;
            return result;
        } else if (D == 0) {
            result = new double[1];
            result[0] = x1;
            return result;
        } else {
            result = new double[0];
            return result;
        }
    }


}
