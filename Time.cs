public class Time{

    //propriedade estática
    static int numero = 1;

    //propriedade do time
    public string nomePO;
    public int titNacionalPO;
    public int titEstadualPO;
    public string estadoPO;

    public Time (string clube, int titn, int tite, string est){
        numero++;

        this.nomePO = clube;
        this.titNacionalPO = titn;
        this.titEstadualPO = tite;
        this.estadoPO = est;

    }

}