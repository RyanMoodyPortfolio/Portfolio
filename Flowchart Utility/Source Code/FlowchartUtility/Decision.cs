class Decision
{
    // Member variables

    private string m_strIDreference;
    private string m_strDescription;

    // Constructor

    public Decision(string strIDreference, string strDescription)
    {
        m_strIDreference = strIDreference;
        m_strDescription = strDescription;
    }

    // Access procedure

    public string getIDreference()
    {
        return m_strIDreference;
    }

    // ToString is overriden so that the decisions 
    // in the combo box are displayed correctly

    public override string ToString()
    {
        return m_strDescription;
    }
}