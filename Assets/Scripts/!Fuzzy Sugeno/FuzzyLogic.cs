
using UnityEngine;

public class FuzzyLogic : MonoBehaviour
{
    [Header("Pemanggilan class lain")]
    private PlayerStat playerStat;
    private Timestamp timestamp;

    [Header("Value Variabel")]
    public int jumlahKoin;
    public int jumlahNyawa;
    public int jumlahSkor;
    public int jumlahWaktu;

    [Header("Himpunan Fuzzy")]
    public float[] variabelSkor = new float[5];
    public float[] variabelJumlahNyawa = new float[5];
    public float[] variabelJumlahKoin = new float[5];
    public float[] variabelWaktu = new float[5];
    public float[] variabelInformasi = new float[5];
    public float[] variabelReward = new float[5];

    [Header("Rules Implikasi")]
    //public float[,] rulesImplikasi = new float[25,4];
    public float[,] rulesImplikasi = new float[625, 4];
    public float[] nilaiMinImplikasi = new float[625];

    [Header("Defuzzyfikasi")]
    public int[] nilaiOutput = new int[625];

    public float hasilAkhir;

    public bool isFinish = false;

    private void Start()
    {
        playerStat = FindAnyObjectByType<PlayerStat>();
        timestamp = FindAnyObjectByType<Timestamp>();

        nilaiOutput = new int[] {
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 4, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2,
        1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        3, 3, 3, 3, 4, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 2, 2, 2, 2, 3,
        2, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 3, 4, 3, 3, 3, 4, 5,
        3, 3, 3, 4, 4, 3, 3, 3, 4, 4, 3, 3, 3, 4, 4, 3, 3, 3, 5, 5,
        4, 4, 5, 5, 5};

    }

    private void Update()
    {
        // Matiin ini kalo mau ubah2 tanpa main game
        // jumlahKoin = playerStat.coinValue;
        // jumlahNyawa = playerStat.currentHealth;
        // jumlahWaktu = timestamp.minute;
        // jumlahSkor = playerStat.playerScore;

        KeanggotaanJumlahKoin();
        KeanggotaanJumlahNyawa();
        KeanggotaanSkor();
        KeanggotaanWaktu();

        HitungImplikasiJumlahKoin();
        HitungImplikasiJumlahNyawa();
        HitungImplikasiSkor();
        HitungImplikasiWaktu();
        HitungMinImplikasi();
        Defuzzyfikasi();

        //if (isFinish)
        //{
        //    HitungImplikasiJumlahKoin();
        //    HitungImplikasiJumlahNyawa();
        //    HitungImplikasiSkor();
        //    HitungImplikasiWaktu();
        //    HitungMinImplikasi();
        //    Defuzzyfikasi();
        //}

    }

    #region FUZZYFIKASI

    #region KOIN

    private void KoinSangatBanyak()
    {
        if(jumlahKoin >= 50)
        {
            variabelJumlahKoin[4] = 1;
        }
        else if(jumlahKoin > 40 && jumlahKoin < 50)
        {
            variabelJumlahKoin[4] = (float)(jumlahKoin - 40) / (50 - 40);
        }
        else
        {
            variabelJumlahKoin[4] = 0;
        }
    }

    private void KoinBanyak()
    {
        if(jumlahKoin > 37.5f && jumlahKoin < 45)
        {
            variabelJumlahKoin[3] = (float)(45 - jumlahKoin) / (45 - 37.5f);
        }
        else if(jumlahKoin > 30 && jumlahKoin <= 37.5f)
        {
            variabelJumlahKoin[3] = (float)(jumlahKoin - 30) / (37.5f - 30);
        }
        else
        {
            variabelJumlahKoin[3] = 0;
        }
    }

    private void KoinSedang()
    {
        if(jumlahKoin > 27.5f && jumlahKoin < 35)
        {
            variabelJumlahKoin[2] = (float)(35 - jumlahKoin) / (35 - 27.5f);
        }
        else if(jumlahKoin > 20 && jumlahKoin <= 27.5f)
        {
            variabelJumlahKoin[2] = (float)(jumlahKoin - 20) / (27.5f - 20);
        }
        else
        {
            variabelJumlahKoin[2] = 0;
        }
    }

    private void KoinSedikit()
    {
        if (jumlahKoin > 17.5f && jumlahKoin < 25)
        {
            variabelJumlahKoin[1] = (float)(25 - jumlahKoin) / (25 - 17.5f);
        }
        else if (jumlahKoin > 10 && jumlahKoin <= 17.5f)
        {
            variabelJumlahKoin[1] = (float)(jumlahKoin - 10) / (17.5f - 10);
        }
        else
        {
            variabelJumlahKoin[1] = 0;
        }
    }

    private void KoinSangatSedikit()
    {
        if (jumlahKoin >= 15)
        {
            variabelJumlahKoin[0] = 0;
        }
        else if(jumlahKoin > 0 &&  jumlahKoin < 15)
        {
            variabelJumlahKoin[0] = (float)(15 - jumlahKoin) / (15 - 0);
        }
        else
        {
            variabelJumlahKoin[0] = 1;
        }
    }

    private void KeanggotaanJumlahKoin()
    {
        KoinSangatBanyak();
        KoinBanyak();
        KoinSedang();
        KoinSedikit();
        KoinSangatSedikit();
    }
    #endregion

    #region NYAWA

    private void NyawaSangatBanyak()
    {
        if (jumlahNyawa >= 100)
        {
            variabelJumlahNyawa[4] = 1;
        }
        else if (jumlahNyawa > 85 && jumlahNyawa < 100)
        {
            variabelJumlahNyawa[4] = (float)(jumlahNyawa - 85) / (100 - 85);
        }
        else
        {
            variabelJumlahNyawa[4] = 0;
        }
    }

    private void NyawaBanyak()
    {
        if (jumlahNyawa > 80 && jumlahNyawa < 90)
        {
            variabelJumlahNyawa[3] = (float)(90 - jumlahNyawa) / (90 - 80);
        }
        else if (jumlahNyawa > 70 && jumlahNyawa <= 80)
        {
            variabelJumlahNyawa[3] = (float)(jumlahNyawa - 70) / (80 - 70);
        }
        else
        {
            variabelJumlahNyawa[3] = 0;
        }
    }

    private void NyawaSedang()
    {
        if (jumlahNyawa > 60 && jumlahNyawa < 75)
        {
            variabelJumlahNyawa[2] = (float)(75 - jumlahNyawa) / (75 - 60);
        }
        else if (jumlahNyawa > 45 && jumlahNyawa <= 60)
        {
            variabelJumlahNyawa[2] = (float)(jumlahNyawa - 45) / (60 - 45);
        }
        else
        {
            variabelJumlahNyawa[2] = 0;
        }
    }

    private void NyawaSedikit()
    {
        if (jumlahNyawa > 37.5f && jumlahNyawa < 50)
        {
            variabelJumlahNyawa[1] = (float)(50 - jumlahNyawa) / (50 - 37.5f);
        }
        else if (jumlahNyawa > 25 && jumlahNyawa <= 37.5f)
        {
            variabelJumlahNyawa[1] = (float)(jumlahNyawa - 25) / (37.5f - 25);
        }
        else
        {
            variabelJumlahNyawa[1] = 0;
        }
    }

    private void NyawaSangatSedikit()
    {
        if (jumlahNyawa >= 30)
        {
            variabelJumlahNyawa[0] = 0;
        }
        else if (jumlahNyawa > 0 && jumlahNyawa < 30)
        {
            variabelJumlahNyawa[0] = (float)(30 - jumlahNyawa) / (30 - 0);
        }
        else
        {
            variabelJumlahNyawa[0] = 1;
        }
    }

    private void KeanggotaanJumlahNyawa()
    {
        NyawaSangatBanyak();
        NyawaBanyak();
        NyawaSedang();
        NyawaSedikit();
        NyawaSangatSedikit();
    }

    #endregion

    #region SKOR
    private void SkorSangatTinggi()
    {
        if (jumlahSkor >= 100)
        {
            variabelSkor[4] = 1;
        }
        else if (jumlahSkor > 85 && jumlahSkor < 100)
        {
            variabelSkor[4] = (float)(jumlahSkor - 85) / (100 - 85);
        }
        else
        {
            variabelSkor[4] = 0;
        }
    }

    private void SkorTinggi()
    {
        if (jumlahSkor > 80 && jumlahSkor < 90)
        {
            variabelSkor[3] = (float)(90 - jumlahSkor) / (90 - 80);
        }
        else if (jumlahSkor > 70 && jumlahSkor <= 80)
        {
            variabelSkor[3] = (float)(jumlahSkor - 70) / (80 - 70);
        }
        else
        {
            variabelSkor[3] = 0;
        }
    }

    private void SkorSedang()
    {
        if (jumlahSkor > 60 && jumlahSkor < 75)
        {
            variabelSkor[2] = (float)(75 - jumlahSkor) / (75 - 60);
        }
        else if (jumlahSkor > 45 && jumlahSkor <= 60)
        {
            variabelSkor[2] = (float)(jumlahSkor - 45) / (60 - 45);
        }
        else
        {
            variabelSkor[2] = 0;
        }
    }

    private void SkorRendah()
    {
        if (jumlahSkor > 37.5f && jumlahSkor < 50)
        {
            variabelSkor[1] = (float)(50 - jumlahSkor) / (50 - 37.5f);
        }
        else if (jumlahSkor > 25 && jumlahSkor <= 37.5f)
        {
            variabelSkor[1] = (float)(jumlahSkor - 25) / (37.5f - 25);
        }
        else
        {
            variabelSkor[1] = 0;
        }
    }

    private void SkorSangatRendah()
    {
        if (jumlahSkor >= 30)
        {
            variabelSkor[0] = 0;
        }
        else if (jumlahSkor > 0 && jumlahSkor < 30)
        {
            variabelSkor[0] = (float)(30 - jumlahSkor) / (30 - 0);
        }
        else
        {
            variabelSkor[0] = 1;
        }
    }

    private void KeanggotaanSkor()
    {
        SkorSangatTinggi();
        SkorTinggi();
        SkorSedang();
        SkorRendah();
        SkorSangatRendah();
    }
    #endregion

    #region WAKTU

    private void WaktuSangatLambat()
    {
        if (jumlahWaktu >= 50)
        {
            variabelWaktu[0] = 1;
        }
        else if (jumlahWaktu > 40 && jumlahWaktu < 50)
        {
            variabelWaktu[0] = (float)(jumlahWaktu - 40) / (50 - 40);
        }
        else
        {
            variabelWaktu[0] = 0;
        }

    }

    private void WaktuLambat()
    {
        if (jumlahWaktu > 37.5f && jumlahWaktu < 45)
        {
            variabelWaktu[1] = (float)(45 - jumlahWaktu) / (45 - 37.5f);
        }
        else if (jumlahWaktu > 30 && jumlahWaktu <= 37.5f)
        {
            variabelWaktu[1] = (float)(jumlahWaktu - 30) / (37.5f - 30);
        }
        else
        {
            variabelWaktu[1] = 0;
        }
    }

    private void WaktuSedang()
    {
        if (jumlahWaktu > 27.5f && jumlahWaktu < 35)
        {
            variabelWaktu[2] = (float)(35 - jumlahWaktu) / (35 - 27.5f);
        }
        else if (jumlahWaktu > 20 && jumlahWaktu <= 27.5f)
        {
            variabelWaktu[2] = (float)(jumlahWaktu - 20) / (27.5f - 20);
        }
        else
        {
            variabelWaktu[2] = 0;
        }
    }

    private void WaktuCepat()
    {
        if (jumlahWaktu > 17.5f && jumlahWaktu < 25)
        {
            variabelWaktu[3] = (float)(25 - jumlahWaktu) / (25 - 17.5f);
        }
        else if (jumlahWaktu > 10 && jumlahWaktu <= 17.5f)
        {
            variabelWaktu[3] = (float)(jumlahWaktu - 10) / (17.5f - 10);
        }
        else
        {
            variabelWaktu[3] = 0;
        }
    }

    private void WaktuSangatCepat()
    {
        if (jumlahWaktu >= 15)
        {
            variabelWaktu[4] = 0;
        }
        else if (jumlahWaktu > 0 && jumlahWaktu < 15)
        {
            variabelWaktu[4] = (float)(15 - jumlahWaktu) / (15 - 0);
        }
        else
        {
            variabelWaktu[4] = 1;
        }
    }

    private void KeanggotaanWaktu()
    {
        WaktuSangatLambat();
        WaktuLambat();
        WaktuSedang();
        WaktuCepat();
        WaktuSangatCepat();
    }

    #endregion

    #endregion

    #region IMPLIKASI

    private void HitungImplikasiJumlahKoin()
    {
        for (int i = 0; i < 625; i++)
        {
            if (i < 125)
            {
                rulesImplikasi[i, 0] = variabelJumlahKoin[0];
            }
            else if (i < 250)
            {
                rulesImplikasi[i, 0] = variabelJumlahKoin[1];
            }
            else if (i < 375)
            {
                rulesImplikasi[i, 0] = variabelJumlahKoin[2];
            }
            else if (i < 500)
            {
                rulesImplikasi[i, 0] = variabelJumlahKoin[3];
            }
            else if (i < 625)
            {
                rulesImplikasi[i, 0] = variabelJumlahKoin[4];
            }
        }
    }

    private void HitungImplikasiJumlahNyawa()
    {
        for (int i = 0; i < 625; i++)
        {
            if(i < 25)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[0];
            }
            else if(i < 50)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[1];
            }
            else if(i < 75)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[2];
            }
            else if(i < 100)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[3];
            }
            else if(i < 125)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[4];
            }
            else if (i < 150)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[0];
            }
            else if (i < 175)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[1];
            }
            else if (i < 200)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[2];
            }
            else if (i < 225)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[3];
            }
            else if (i < 250)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[4];
            }
            else if (i < 275)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[0];
            }
            else if (i < 300)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[1];
            }
            else if (i < 325)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[2];
            }
            else if (i < 350)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[3];
            }
            else if (i < 375)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[4];
            }
            else if (i < 400)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[0];
            }
            else if (i < 425)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[1];
            }
            else if (i < 450)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[2];
            }
            else if (i < 475)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[3];
            }
            else if (i < 500)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[4];
            }
            else if (i < 525)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[0];
            }
            else if (i < 550)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[1];
            }
            else if (i < 575)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[2];
            }
            else if (i < 600)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[3];
            }
            else if (i < 625)
            {
                rulesImplikasi[i, 1] = variabelJumlahNyawa[4];
            }
        }
    }

    private void HitungImplikasiSkor()
    {
        int patternLength = 25;

        for (int i = 0; i < 625; i++)
        {
            int patternIndex = i % patternLength;

            if (patternIndex < 5)
            {
                rulesImplikasi[i, 2] = variabelSkor[0];
            }
            else if (patternIndex < 10)
            {
                rulesImplikasi[i, 2] = variabelSkor[1];
            }
            else if (patternIndex < 15)
            {
                rulesImplikasi[i, 2] = variabelSkor[2];
            }
            else if (patternIndex < 20)
            {
                rulesImplikasi[i, 2] = variabelSkor[3];
            }
            else if (patternIndex < 25)
            {
                rulesImplikasi[i, 2] = variabelSkor[4];
            }

        }
    }

    private void HitungImplikasiWaktu()
    {
        int patternLength = 5;

        for (int i = 0; i < 625; i++)
        {
            int patternIndex = i % patternLength;

            if (patternIndex < 1)
            {
                rulesImplikasi[i, 3] = variabelWaktu[0];
            }
            else if (patternIndex < 2)
            {
                rulesImplikasi[i, 3] = variabelWaktu[1];
            }
            else if (patternIndex < 3)
            {
                rulesImplikasi[i, 3] = variabelWaktu[2];
            }
            else if (patternIndex < 4)
            {
                rulesImplikasi[i, 3] = variabelWaktu[3];
            }
            else if (patternIndex < 5)
            {
                rulesImplikasi[i, 3] = variabelWaktu[4];
            }

        }
    }

    private void HitungMinImplikasi()
    {
        //for(int baris = 0; baris <  rulesImplikasi.GetLength(0); baris++) 
        //{
        //    float nilaiMin = rulesImplikasi[baris, 0];

        //    for (int kolom = 1; kolom < rulesImplikasi.GetLength(1); kolom++)
        //    {
        //        if (rulesImplikasi[baris, kolom] < nilaiMin)
        //        {
        //            nilaiMin = rulesImplikasi[baris, kolom];
        //        }
        //    }
        //    nilaiMinImplikasi[baris] = nilaiMin;
        //}



        for (int i = 0; i < 625; i++)
        {
            float nilaiMin = rulesImplikasi[i, 0];

            for (int j = 1; j < 4; j++)
            {
                if (rulesImplikasi[i, j] < nilaiMin)
                {
                    nilaiMin = rulesImplikasi[i, j];
                }
            }

            nilaiMinImplikasi[i] = nilaiMin;
        }
    }

    #endregion

    #region DEFUZZYFIKASI

    float HasilDefuzzyfikasi()
    {
        float hasil = 0;
        float totalNilaiPembagi = 0;

        for (int i = 0; i < nilaiOutput.Length; i++)
        {
            hasil += nilaiMinImplikasi[i] * nilaiOutput[i];
            totalNilaiPembagi += nilaiMinImplikasi[i];
        }

        if (totalNilaiPembagi != 0)
        {
            hasil /= totalNilaiPembagi;
        }
        else
        {
            Debug.LogWarning("Total Nilai Pembagi 0, Gak bisa bagi angka 0");
        }
        return hasil;
    }

    private void Defuzzyfikasi()
    {
        hasilAkhir = HasilDefuzzyfikasi();
    }

    #endregion
}
