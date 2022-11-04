class Tela{
    // propriedades
    ConsoleColor corTexto, corFundo;

    public Tela ( ){
        this.corFundo = ConsoleColor.Black;
        this.corTexto = ConsoleColor.DarkRed;

        this.configurarTela();
    }

    public void configurarTela(){
        Console.BackgroundColor = this.corFundo;
        Console.ForegroundColor = this.corTexto;
        Console.Clear();
    }

    public void montarTelaSistema(){
        this.montarMoldura(0,0,90,23);
        this.montarLinhaHor(2,0,90);
        this.centralizar(1,0,59,"Clubes Brasileiros");
    }

    public void montarMoldura(int ci, int li, int cf, int lf){
        int col, lin;
        this.limparArea(ci,li,cf,lf);

        for (col=ci; col<=cf; col++){
            Console.SetCursorPosition(col,li);
            Console.Write("-");
            Console.SetCursorPosition(col,lf);
            Console.Write("-");
        }

        for (lin=li; lin<=lf; lin++){
            Console.SetCursorPosition(ci,lin);
            Console.Write("|");
            Console.SetCursorPosition(cf,lin);
            Console.Write("|");
        }

        Console.SetCursorPosition(ci,li); Console.Write("+");
        Console.SetCursorPosition(ci,lf); Console.Write("+");
        Console.SetCursorPosition(cf,li); Console.Write("+");
        Console.SetCursorPosition(cf,lf); Console.Write("+");
    }

    public void limparArea(int ci, int li, int cf, int lf){
        int col, lin;

        for (col=ci; col<=cf; col++){
            for (lin=li; lin<=lf; lin++){
                Console.SetCursorPosition(col,lin);
                Console.Write(" ");
            }
        }
    }

    public void montarLinhaHor(int lin, int ci, int cf){
        int col;
        for (col=ci; col<=cf; col++){
            Console.SetCursorPosition(col,lin);
            Console.Write("-");
        }

        Console.SetCursorPosition(ci, lin);
        Console.Write("+");
        Console.SetCursorPosition(cf, lin);
        Console.Write("+");
    }

    public void centralizar(int lin, int ci, int cf, string msg){
        int col;
        col = ci+((cf-ci)/2);
        Console.SetCursorPosition(col,lin);
        Console.Write(msg);
    }

    public string mostrarMenu(List<string> menu,int ci,int li){
        int cf,lf,x;
        string op;

        cf = ci + menu[0].Length + 1;
        lf = li + menu.Count() + 2;

        this.montarMoldura(ci,li,cf,lf);

        for (x = 0; x < menu.Count(); x++){
            Console.SetCursorPosition( ci+1, li+x+1);
            Console.Write(menu[x]);
        }
        Console.SetCursorPosition( ci+1, li+x+1);
        Console.Write("Opção: ");
        op = Console.ReadLine();
        return op;
    }

    public string perguntar(int col, int lin, string perg){
        string resp;
        Console.SetCursorPosition(col,lin);
        Console.Write(perg);
        resp = Console.ReadLine();
        return resp;
    }

}