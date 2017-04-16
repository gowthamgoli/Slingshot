using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuration : MonoBehaviour
{

    public Vector3 planet1;
    public Vector3 planet2;
    public Vector3 planet3;
    public Vector3 planet4;


    public float scale1;
    public float scale2;
    public float scale3;
    public float scale4;

    public Configuration(Vector3 p1, float s1, Vector3 p2, float s2)
    {
        planet1 = p1;
        planet2 = p2;
        planet3 = Vector3.zero;
        planet4 = Vector3.zero;
        scale1 = s1;
        scale2 = s2;
        scale3 = 0f;
        scale4 = 0f;
    }

    public Configuration(Vector3 p1, float s1, Vector3 p2, float s2, Vector3 p3, float s3)
    {
        planet1 = p1;
        planet2 = p2;
        planet3 = p3;
        planet4 = Vector3.zero;
        scale1 = s1;
        scale2 = s2;
        scale3 = s3;
        scale4 = 0f;
    }

    public Configuration(Vector3 p1, float s1, Vector3 p2, float s2, Vector3 p3, float s3, Vector3 p4, float s4)
    {
        planet1 = p1;
        planet2 = p2;
        planet3 = p3;
        planet4 = p4;
        scale1 = s1;
        scale2 = s2;
        scale3 = s3;
        scale4 = s4;
    }

    public Configuration()
    {
    }

    public Configuration[] getList()
    {
        Configuration[] t = new Configuration[83];

        t[0] = new Configuration(new Vector3(4.928701f, -0.4573321f, 0.0f), 2.127476f, new Vector3(-2.189986f, -2.585663f, 0.0f), 3.311954f);
        t[1] = new Configuration(new Vector3(5.307081f, 1.705047f, 0.0f), 2.051611f, new Vector3(-2.289449f, 0.05955601f, 0.0f), 3.708642f);
        t[2] = new Configuration(new Vector3(-1.26403f, 1.712624f, 0.0f), 2.058262f, new Vector3(2.490782f, -1.43698f, 0.0f), 3.721317f);
        t[3] = new Configuration(new Vector3(-3.14446f, 2.062414f, 0.0f), 2.090582f, new Vector3(2.8034f, -2.084232f, 0.0f), 3.654515f);
        t[4] = new Configuration(new Vector3(-2.843355f, 1.81069f, 0.0f), 2.000096f, new Vector3(0.4306393f, -2.00752f, 0.0f), 3.307066f);
        t[5] = new Configuration(new Vector3(-3.217594f, 2.208621f, 0.0f), 2.105528f, new Vector3(2.678688f, -0.2408633f, 0.0f), 2.771967f);
        t[6] = new Configuration(new Vector3(3.477581f, 2.979741f, 0.0f), 2.190657f, new Vector3(-3.309999f, -1.390558f, 0.0f), 3.600791f);
        t[7] = new Configuration(new Vector3(2.74954f, -1.458377f, 0.0f), 2.560983f, new Vector3(-2.867501f, 2.326305f, 0.0f), 2.762874f);
        t[8] = new Configuration(new Vector3(-4.15255f, 1.065881f, 0.0f), 2.127915f, new Vector3(3.710193f, -1.210969f, 0.0f), 3.657657f);
        t[9] = new Configuration(new Vector3(3.652259f, 0.9605626f, 0.0f), 2.631174f, new Vector3(-3.600167f, -2.72015f, 0.0f), 2.833162f);
        t[10] = new Configuration(new Vector3(1.548244f, 2.216413f, 0.0f), 2.423983f, new Vector3(-1.015198f, -2.899712f, 0.0f), 2.934392f);
        t[11] = new Configuration(new Vector3(1.517446f, -2.697546f, 0.0f), 2.56286f, new Vector3(-2.950621f, 2.102084f, 0.0f), 3.199423f);
        t[12] = new Configuration(new Vector3(-3.5351f, 2.079119f, 0.0f), 2.449455f, new Vector3(0.3967657f, -1.821688f, 0.0f), 2.967278f);
        t[13] = new Configuration(new Vector3(-0.2807798f, -2.908889f, 0.0f), 2.744107f, new Vector3(4.206955f, 2.239441f, 0.0f), 2.86192f);
        t[14] = new Configuration(new Vector3(4.045833f, -1.374437f, 0.0f), 2.147571f, new Vector3(-1.811426f, 0.9461287f, 0.0f), 2.974541f);
        t[15] = new Configuration(new Vector3(4.412753f, -0.5626693f, 0.0f), 2.050065f, new Vector3(-2.806316f, 0.8114003f, 0.0f), 3.574956f);
        t[16] = new Configuration(new Vector3(3.310897f, 0.8360194f, 0.0f), 2.723018f, new Vector3(-3.561676f, -1.332309f, 0.0f), 3.278316f);
        t[17] = new Configuration(new Vector3(3.901569f, -0.485383f, 0.0f), 2.119228f, new Vector3(-2.481791f, 1.572523f, 0.0f), 3.152038f);
        t[18] = new Configuration(new Vector3(4.835936f, -1.85897f, 0.0f), 2.513529f, new Vector3(-3.120067f, 1.148353f, 0.0f), 3.620489f);
        t[19] = new Configuration(new Vector3(3.380657f, -2.496882f, 0.0f), 2.211131f, new Vector3(-4.457563f, 2.965289f, 0.0f), 3.402234f);
        t[20] = new Configuration(new Vector3(-2.158689f, 0.6713996f, 0.0f), 2.288563f, new Vector3(4.579615f, -2.201342f, 0.0f), 2.914421f);
        t[21] = new Configuration(new Vector3(2.859481f, 2.803101f, 0.0f), 2.693899f, new Vector3(-4.687114f, -0.9800425f, 0.0f), 3.457294f);
        t[22] = new Configuration(new Vector3(2.174071f, -2.862509f, 0.0f), 2.580904f, new Vector3(-5.128393f, -1.848877f, 0.0f), 3.025257f);
        t[23] = new Configuration(new Vector3(1.436852f, -2.648939f, 0.0f), 2.055198f, new Vector3(-3.216196f, -1.517404f, 0.0f), 3.083616f);
        t[24] = new Configuration(new Vector3(-2.661788f, 2.616902f, 0.0f), 2.621588f, new Vector3(3.626199f, 0.05122614f, 0.0f), 2.925798f);
        t[25] = new Configuration(new Vector3(-2.462194f, 0.5853834f, 0.0f), 2.180392f, new Vector3(4.142774f, -2.10812f, 0.0f), 2.876621f);
        t[26] = new Configuration(new Vector3(-4.079887f, -1.070292f, 0.0f), 2.330168f, new Vector3(3.976082f, -2.259239f, 0.0f), 3.45042f);
        t[27] = new Configuration(new Vector3(3.205397f, -2.634926f, 0.0f), 2.705005f, new Vector3(-0.5994654f, 2.467714f, 0.0f), 3.233959f);
        t[28] = new Configuration(new Vector3(-5.121131f, 0.4319434f, 0.0f), 2.289337f, new Vector3(3.314984f, -1.803009f, 0.0f), 3.50915f);
        t[29] = new Configuration(new Vector3(-1.630118f, -2.700895f, 0.0f), 2.493939f, new Vector3(1.549269f, 2.906583f, 0.0f), 3.718774f);
        t[30] = new Configuration(new Vector3(3.215439f, 2.776515f, 0.0f), 2.357851f, new Vector3(-4.684921f, -0.7966266f, 0.0f), 2.846585f);
        t[31] = new Configuration(new Vector3(-3.378114f, 1.408686f, 0.0f), 2.079388f, new Vector3(3.797856f, -1.513739f, 0.0f), 3.50702f);
        t[32] = new Configuration(new Vector3(3.968721f, -1.302839f, 0.0f), 2.236664f, new Vector3(-3.153458f, -2.987809f, 0.0f), 2.882717f);
        t[33] = new Configuration(new Vector3(3.79388f, 1.326243f, 0.0f), 2.68131f, new Vector3(-1.951353f, -0.1627941f, 0.0f), 3.243458f);
        t[34] = new Configuration(new Vector3(3.589574f, -0.4786816f, 0.0f), 2.509345f, new Vector3(-3.87302f, 1.62674f, 0.0f), 3.32817f);
        t[35] = new Configuration(new Vector3(3.573449f, 1.023158f, 0.0f), 2.199885f, new Vector3(-3.496889f, 0.4663949f, 0.0f), 2.862658f);
        t[36] = new Configuration(new Vector3(-0.04447937f, 2.796961f, 0.0f), 2.059843f, new Vector3(0.5059271f, -2.358714f, 0.0f), 3.366182f);
        t[37] = new Configuration(new Vector3(-3.779626f, -0.1284709f, 0.0f), 2.304489f, new Vector3(1.987209f, -2.099408f, 0.0f), 2.90854f);

        ////// / 3 Planets
        /// 
        /// 

        t[38] = new Configuration(new Vector3(-4.740358f, -1.22534f, 0.0f), 1.946275f, new Vector3(4.343772f, 2.453344f, 0.0f), 2.562315f, new Vector3(1.239259f, -2.225186f, 0.0f), 2.843772f);
        t[39] = new Configuration(new Vector3(-1.263523f, 2.176333f, 0.0f), 1.76681f, new Vector3(3.60286f, -1.611866f, 0.0f), 2.338771f, new Vector3(-3.523533f, -2.600351f, 0.0f), 3.214682f);
        t[40] = new Configuration(new Vector3(2.3962f, 2.958514f, 0.0f), 1.711676f, new Vector3(-5.192837f, -0.9601208f, 0.0f), 2.284483f, new Vector3(3.148719f, -2.069415f, 0.0f), 2.958359f);
        t[41] = new Configuration(new Vector3(-1.556762f, 2.633368f, 0.0f), 1.87124f, new Vector3(3.642769f, -1.81293f, 0.0f), 2.691052f, new Vector3(-3.704211f, -2.787941f, 0.0f), 3.536448f);
        t[42] = new Configuration(new Vector3(-5.533669f, 3.023107f, 0.0f), 1.645718f, new Vector3(4.806813f, -0.06377935f, 0.0f), 2.368759f, new Vector3(-2.385811f, -2.899423f, 0.0f), 3.26494f);
        t[43] = new Configuration(new Vector3(2.902596f, 3.444331f, 0.0f), 1.679176f, new Vector3(-1.698797f, -1.212498f, 0.0f), 2.534532f, new Vector3(3.745478f, -3.448381f, 0.0f), 3.210929f);
        t[44] = new Configuration(new Vector3(1.392478f, 3.402762f, 0.0f), 1.827286f, new Vector3(-5.07538f, -2.338001f, 0.0f), 2.129892f, new Vector3(0.3183613f, -1.796725f, 0.0f), 2.913285f);
        t[45] = new Configuration(new Vector3(-0.1081991f, 0.5528919f, 0.0f), 1.506071f, new Vector3(4.007948f, 2.385808f, 0.0f), 2.16438f, new Vector3(-4.517272f, -1.640066f, 0.0f), 3.126267f);
        t[46] = new Configuration(new Vector3(2.649542f, 1.508805f, 0.0f), 1.611857f, new Vector3(2.294956f, -3.312074f, 0.0f), 2.058147f, new Vector3(-3.746252f, 0.2684312f, 0.0f), 3.119313f);
        t[47] = new Configuration(new Vector3(-4.297985f, 0.8297807f, 0.0f), 1.925337f, new Vector3(-1.097343f, -2.948231f, 0.0f), 2.489091f, new Vector3(3.016376f, 2.344251f, 0.0f), 3.710168f);
        t[48] = new Configuration(new Vector3(-4.173502f, 2.869085f, 0.0f), 1.859683f, new Vector3(4.400665f, 2.47926f, 0.0f), 2.162386f, new Vector3(-0.4566555f, -2.689273f, 0.0f), 3.628762f);
        t[49] = new Configuration(new Vector3(3.354982f, 3.47556f, 0.0f), 1.964324f, new Vector3(-4.558242f, 2.170715f, 0.0f), 2.185008f, new Vector3(1.714887f, -2.77702f, 0.0f), 3.659402f);
        t[50] = new Configuration(new Vector3(1.631673f, 0.3728752f, 0.0f), 1.827912f, new Vector3(-4.777811f, 1.552571f, 0.0f), 2.574406f, new Vector3(5.843845f, -2.393065f, 0.0f), 2.856549f);
        t[51] = new Configuration(new Vector3(5.438076f, -2.24059f, 0.0f), 1.7317f, new Vector3(-4.56025f, 1.732723f, 0.0f), 2.028268f, new Vector3(0.7172489f, -0.258697f, 0.0f), 2.903672f);
        t[52] = new Configuration(new Vector3(2.870749f, -3.113727f, 0.0f), 1.840531f, new Vector3(2.498554f, 2.951158f, 0.0f), 2.303974f, new Vector3(-2.961068f, -2.262945f, 0.0f), 3.749197f);
        t[53] = new Configuration(new Vector3(-0.4950867f, -1.296619f, 0.0f), 1.898879f, new Vector3(5.329468f, -2.091854f, 0.0f), 2.560518f, new Vector3(-4.595438f, 2.284872f, 0.0f), 2.958439f);
        t[54] = new Configuration(new Vector3(-0.5965528f, -0.09932184f, 0.0f), 1.863416f, new Vector3(4.470437f, -0.1438122f, 0.0f), 2.667484f, new Vector3(-5.340961f, -2.244526f, 0.0f), 2.882954f);
        t[55] = new Configuration(new Vector3(1.430075f, 3.4465f, 0.0f), 1.523995f, new Vector3(-3.242772f, -0.955341f, 0.0f), 2.04228f, new Vector3(3.434887f, -1.115306f, 0.0f), 3.246606f);
        t[56] = new Configuration(new Vector3(-4.317982f, -1.791254f, 0.0f), 1.771896f, new Vector3(-1.15301f, 2.080792f, 0.0f), 2.441569f, new Vector3(4.621206f, -0.3662221f, 0.0f), 3.207141f);
        t[57] = new Configuration(new Vector3(2.81696f, 1.493492f, 0.0f), 1.527428f, new Vector3(-3.046402f, 2.995628f, 0.0f), 2.250977f, new Vector3(1.643742f, -3.454061f, 0.0f), 3.313653f);
        t[58] = new Configuration(new Vector3(4.187162f, 2.527999f, 0.0f), 1.60383f, new Vector3(-3.157758f, 3.084311f, 0.0f), 2.200975f, new Vector3(0.5383368f, -1.214095f, 0.0f), 2.82198f);
        t[59] = new Configuration(new Vector3(-3.495207f, -1.98994f, 0.0f), 1.816479f, new Vector3(4.509714f, -1.99373f, 0.0f), 2.641629f, new Vector3(-1.741152f, 3.155438f, 0.0f), 3.074185f);
        t[60] = new Configuration(new Vector3(2.574888f, 2.162135f, 0.0f), 1.662155f, new Vector3(-2.43765f, 3.180684f, 0.0f), 2.548445f, new Vector3(2.317835f, -3.452179f, 0.0f), 3.13269f);
        t[61] = new Configuration(new Vector3(1.728863f, -2.801624f, 0.0f), 1.907742f, new Vector3(2.625879f, 2.268441f, 0.0f), 2.670131f, new Vector3(-3.234089f, -1.457416f, 0.0f), 3.099925f);
        t[62] = new Configuration(new Vector3(-0.6778831f, 3.387305f, 0.0f), 1.821969f, new Vector3(3.169282f, 1.066295f, 0.0f), 2.025418f, new Vector3(-2.843357f, -1.066889f, 0.0f), 3.011853f);
        t[63] = new Configuration(new Vector3(-0.2698107f, 1.991265f, 0.0f), 1.731417f, new Vector3(4.860455f, 0.9814224f, 0.0f), 2.489656f, new Vector3(-4.711088f, -0.9160829f, 0.0f), 2.799312f);
        t[64] = new Configuration(new Vector3(3.481297f, -1.568408f, 0.0f), 1.728018f, new Vector3(-2.79104f, -1.34105f, 0.0f), 2.380507f, new Vector3(0.7904139f, 3.436994f, 0.0f), 3.19703f);
        t[65] = new Configuration(new Vector3(1.626308f, 3.032691f, 0.0f), 1.851259f, new Vector3(3.05091f, -2.763261f, 0.0f), 2.638542f, new Vector3(-4.489697f, -2.502117f, 0.0f), 3.2629f);
        t[66] = new Configuration(new Vector3(-3.838932f, -0.4227271f, 0.0f), 1.984291f, new Vector3(0.4617643f, 2.477339f, 0.0f), 2.31149f, new Vector3(1.888159f, -2.924684f, 0.0f), 3.55434f);
        t[67] = new Configuration(new Vector3(3.673862f, -2.826024f, 0.0f), 1.946052f, new Vector3(-3.29903f, -3.076993f, 0.0f), 2.314532f, new Vector3(1.559299f, 3.036269f, 0.0f), 3.676362f);
        t[68] = new Configuration(new Vector3(1.551897f, -2.301746f, 0.0f), 1.561525f, new Vector3(3.182524f, 2.442137f, 0.0f), 2.501896f, new Vector3(-2.427699f, 2.149572f, 0.0f), 2.994897f);
        t[69] = new Configuration(new Vector3(-1.746684f, -2.431588f, 0.0f), 1.544317f, new Vector3(-3.731981f, 3.090299f, 0.0f), 2.654147f, new Vector3(2.594379f, 2.397051f, 0.0f), 3.415414f);
        t[70] = new Configuration(new Vector3(3.4078f, 1.543074f, 0.0f), 1.712315f, new Vector3(-4.005541f, -1.548947f, 0.0f), 2.197322f, new Vector3(1.284283f, -2.743318f, 0.0f), 2.779188f);
        t[71] = new Configuration(new Vector3(2.166552f, 1.773764f, 0.0f), 1.997744f, new Vector3(3.857051f, -2.760468f, 0.0f), 2.214271f, new Vector3(-2.358109f, -0.8102902f, 0.0f), 3.322566f);
        t[72] = new Configuration(new Vector3(3.097242f, 2.705997f, 0.0f), 1.67779f, new Vector3(-3.162313f, 1.693116f, 0.0f), 2.700169f, new Vector3(1.131478f, -2.360715f, 0.0f), 3.156914f);
        t[73] = new Configuration(new Vector3(3.283546f, 0.6081635f, 0.0f), 1.818882f, new Vector3(-2.255119f, 2.46105f, 0.0f), 2.523093f, new Vector3(-0.5321064f, -3.075823f, 0.0f), 3.294267f);
        t[74] = new Configuration(new Vector3(1.139891f, 2.737878f, 0.0f), 1.687063f, new Vector3(-3.577972f, 2.03421f, 0.0f), 2.448149f, new Vector3(2.644789f, -2.307214f, 0.0f), 3.523241f);
        t[75] = new Configuration(new Vector3(4.008202f, -1.592799f, 0.0f), 1.8667f, new Vector3(-2.127124f, -3.252841f, 0.0f), 2.085509f, new Vector3(-1.242361f, 1.936564f, 0.0f), 3.365049f);
        t[76] = new Configuration(new Vector3(-2.328526f, -2.202536f, 0.0f), 1.729612f, new Vector3(3.713234f, 2.367954f, 0.0f), 2.256886f, new Vector3(-3.803106f, 3.094044f, 0.0f), 3.024125f);
        t[77] = new Configuration(new Vector3(4.840628f, -2.313679f, 0.0f), 1.994224f, new Vector3(-1.53266f, 2.786643f, 0.0f), 2.023069f, new Vector3(-5.02301f, -3.420433f, 0.0f), 2.886975f);
        t[78] = new Configuration(new Vector3(3.811859f, 0.8043095f, 0.0f), 1.929472f, new Vector3(-3.077741f, 0.1674943f, 0.0f), 2.237562f, new Vector3(0.7524309f, -3.264265f, 0.0f), 2.893797f);
        t[79] = new Configuration(new Vector3(1.50981f, 0.9492464f, 0.0f), 1.686777f, new Vector3(-3.048624f, -1.602732f, 0.0f), 2.417827f, new Vector3(3.852199f, -3.3235f, 0.0f), 2.891616f);
        t[80] = new Configuration(new Vector3(-1.429159f, -1.449423f, 0.0f), 1.645156f, new Vector3(4.396297f, 2.079528f, 0.0f), 2.579956f, new Vector3(-2.76219f, 3.348713f, 0.0f), 3.193733f);
        t[81] = new Configuration(new Vector3(4.980085f, -1.297804f, 0.0f), 1.647194f, new Vector3(-4.506456f, -1.889966f, 0.0f), 2.421761f, new Vector3(2.555214f, 3.103316f, 0.0f), 2.960657f);
        t[82] = new Configuration(new Vector3(3.08898f, 3.03828f, 0.0f), 1.615071f, new Vector3(-1.719164f, 2.327501f, 0.0f), 2.330205f, new Vector3(0.257184f, -3.354056f, 0.0f), 3.689611f);

        //Configuration (new Vector3 (1.0f, 1.0f, 1.0f), new Vector3 (1.0f, 1.0f, 1.0f), 1.0f, 1.2f);
        return t;
    }

}