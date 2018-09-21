/******************************************
 * 版权所有jackch
 * QQ:106050555
 * E-mail:jackch88@hotmail.com
 * 个人Blog:http://www.jackch.cn
 * CSDN_Blog:http://blog.csdn.net/jackch88/
 * ****************************************/
namespace FarsiLibrary.Win
{
    /// <summary>
    /// Hit test result of <see cref="FATabStrip"/>
    /// </summary>
    public enum HitTestResult
    {
        CloseButton,
        MenuGlyph,
        TabItem,
        None
    }
    
    /// <summary>
    /// Theme Type
    /// </summary>
    public enum ThemeTypes
    {
        WindowsXP,
        Office2000,
        Office2003
    }

    /// <summary>
    /// Indicates a change into TabStrip collection
    /// </summary>
    public enum FATabStripItemChangeTypes
    {
        Added,
        Removed,
        Changed,
        SelectionChanged
    }
}
