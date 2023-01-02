using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary {

    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName {Wave, MultiWave, Ripple, Sphere, Torus};

    static Function[] functions = {Wave, MultiWave, Ripple, Sphere, Torus};

    public static Function GetFunction(FunctionName name) {
        return functions[(int)name];
    }

    //This represents f(x, t) = sin(pi*(x+t))
    public static Vector3 Wave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }

    //This represents the famous Weierstrass function which is continous everywhere but differentiable nowhere
    public static float Weierstrass(float x, float t) {
        return Cos(PI * (x + t)) + 0.5f *  Cos(2 * PI * (x + t)) + 0.25f *  Cos(4 * PI * (x + t)) + 0.125f * Cos(8 * PI * (x + t)) + 0.0625f * Cos(16 * PI * (x + t)) + 0.03125f * Cos(32 * PI * (x + t)) + 0.015625f * Cos(64 * PI * (x + t));
    }

    public static Vector3 MultiWave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + .25f * t));
        p.y *= (1f / 2.5f);
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t) {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d -t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }

    public static Vector3 Sphere(float u, float v, float t) {
        float r = .9f + .1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * .5f * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Torus(float u, float v, float t) {
        float r1 = .7f + .1f * Sin(PI * (6f * u + .5f * t));
        float r2 = .15f + .05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}