using System;

/// <summary>
///  クランプ
/// </summary>
public class Clamp{

    /* ==========================================
     * minとxの大きい方とmaxを比べて
     * その小さい方を出力する 
     * そうすると、はmaxとmin の範囲に限定される
     * 
     * ※ return Math.Min(10, Math.Max(0, 5))の場合
     *  最小値0と変動値5では大きい方は後者で、
     *  最大値10と変動値5の小さい方も後者なので
     *  最終的に変動値が返される
     *  
     *  ※変動値が最小値以下の場合は、そもそも最小値が返される
     *  ※変動値が最大値以上の場合は、最大値が返される
     ========================================= */

    /// <summary>
    /// クランプ処理
    /// </summary>
    /// <param name="_num">変動する値</param>
    /// <param name="_min">囲む最小値</param>
    /// <param name="_max">囲む最大値</param>
    /// <returns></returns>
    public static float ClampFloat(float _num, float _min, int _max)
    {
        return Math.Min(_max, Math.Max(_min, _num));
    }

    /// <summary>
    ///  Int型のクランプ処理
    /// </summary>
    /// <param name="_num">変動する値</param>
    /// <param name="_min">囲む最小値</param>
    /// <param name="_max">囲む最大値</param>
    /// <returns></returns>
    public static int ClampInt(int _num, int _min, int _max)
    {
        return Math.Min(_max, Math.Max(_min, _num));
    }
}
