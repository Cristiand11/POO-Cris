class Controle{
    //atributos
    Tela tela;
    public List<Time> bancoDadosPO = new List<Time>();
    public List<Time> bancoDadosSC = new List<Time>();
    public List<Time> bancoDadosRS = new List<Time>();
    int posicao;
    string nome;
    int titNacional;
    int titEstadual;
    string estado;

    //métodos
    public Controle(Tela t){
        this.tela = t;

        //criei times só para ter algo nos bancos de dados
        bancoDadosPO.Add( new Time ("JOINVILLE", 2, 13, "SC"));
        bancoDadosPO.Add( new Time ("INTERNACIONAL", 3, 45, "RS"));
        bancoDadosPO.Add( new Time ("SANTOS", 8, 21, "SP"));
    }

    public void executarCRUD(){
        while (true){
            //monta a tela do CRUD de times
            this.tela.limparArea(0,0,90,30);
            this.tela.montarMoldura(10,5,90,19);
            this.tela.montarLinhaHor(8,10,90);
            this.tela.centralizar(6,10,50,"CRUD de Todos os times");
            this.montarTelaPO();
            this.mostrarDadosPO();

            //solicita o nome do time
            Console.SetCursorPosition(11,14);
            Console.Write("Procure um time: ");
            this.nome = Console.ReadLine();
            if (this.nome == "") break;

            //procura no banco de dados se existe o nome da time informado
            this.posicao = 0;

            bool achou = false;
            foreach (var Time in bancoDadosPO)
            {
                if (this.nome == Time.nomePO){
                    achou = true;

                    break;
                }
                this.posicao++;
            }

            //mostra os dados do time, caso tenha encontrado ou mostra a mensagem de time não encontrado
            if (achou){
                // achou o time e vai mostrar os dados
                tela.limparArea(27,9,89,12);
                tela.limparArea(11,14,89,16);
                this.mostrarDadosPO();

                // pergunta para o usuario o que deseja fazer 
                string resp = this.tela.perguntar(11,14, "Deseja alterar, excluir ou voltar? (A/E/V): ");
                if ( resp.ToUpper() == "A"){
                    // o usuário deseja alterar apenas o nome do time
                    this.nome = this.tela.perguntar(11,16, "Novo nome do clube: ");

                    //pergunta se o usuário confirma alteração
                    this.tela.limparArea (11,13,69,13);
                    resp = this.tela.perguntar(11,18, "Tem certeza meu bom? (S/N); ");
                    if (resp.ToUpper()=="S"){
                        this.bancoDadosPO[this.posicao].nomePO = this.nome;
                    }
                }else if(resp.ToUpper()=="E"){
                    // o usuário quer excluir o clube da face da terra (ou só deste programa msm)
                    this.nome = this.tela.perguntar(11,16, "Exterminar este clube? (S/N): ");

                    // pergunta se o usuário tem certeza
                    resp = this.tela.perguntar (11,18, "Tem certeza meu patrão? (S/N): ");
                    if (resp.ToUpper()=="S"){
                        this.bancoDadosPO.RemoveAt(this.posicao);
                    }
                }
            }else{
                // não achou a porcaria do time, mostra a mensagem e pergunta se quer cadastrar um
                string resp = this.tela.perguntar(11,16, "Time não existente no sistema bichão. Quer cadastrar? (S/N): ");
                if (resp.ToUpper()=="S"){
                    tela.limparArea(27,9,89,12);
                    this.nome = this.tela.perguntar(27,9,"");
                    this.titNacional = Convert.ToInt16(this.tela.perguntar(27,10,"" ));
                    this.titEstadual = Convert.ToInt16(this.tela.perguntar(27,11,"" ));
                    this.estado = this.tela.perguntar(27,12, "");

                    this.tela.limparArea(11,13,69,13);
                    resp = this.tela.perguntar(11,18, "Tem certeza disso? Não vou perguntar de volta.. (S/N): ");
                    if (resp.ToUpper()=="S"){
                        this.bancoDadosPO.Add(new Time(this.nome, this.titNacional, this.titEstadual, this.estado));
                    }
                }
                this.posicao = 0;
            }
        }
    }

    public void executarCRUDSC(){
        while (true){
            //monta a tela do CRUD de times
            this.tela.limparArea(0,0,90,30);
            this.tela.montarMoldura(10,5,90,19);
            this.tela.montarLinhaHor(8,10,90);
            this.tela.centralizar(6,10,50,"CRUD de Todos os times catarinenses");
            this.montarTelaPO();
            this.mostrarDadosSC();

            //solicita o nome do time
            Console.SetCursorPosition(12,15);
            Console.Write("Se der *enter* tu volta!");
            Console.SetCursorPosition(12,14);
            Console.Write("Procure um time catarinense: ");
            this.nome = Console.ReadLine();
            if (this.nome == "") break;

            //procura no banco de dados se existe o nome da time informado
            this.posicao = 0;

            bool achou = false;
            foreach (var Time in bancoDadosSC)
            {
                if (this.nome == Time.nomePO){
                    achou = true;

                    break;
                }
                this.posicao++;
            }

            //mostra os dados do time, caso tenha encontrado ou mostra a mensagem de time não encontrado
            if (achou){
                // achou o time e vai mostrar os dados
                this.mostrarDadosSC();

            }else{
                // não achou a porcaria do time, mostra a mensagem
                string resp = this.tela.perguntar(12,17, "Time não existente no sistema bichão. Deve ser de outro estado. ");
                this.posicao = 0;
            }
        }
    }
    
    public void executarCRUDRS(){
        while (true){
            //monta a tela do CRUD de times
            this.tela.limparArea(0,0,90,30);
            this.tela.montarMoldura(10,5,90,19);
            this.tela.montarLinhaHor(8,10,90);
            this.tela.centralizar(6,10,50,"CRUD de Todos os times gauchos");
            this.montarTelaPO();
            this.mostrarDadosRS();

            //solicita o nome do time
            Console.SetCursorPosition(12,15);
            Console.Write("Se der *enter* tu volta!");
            Console.SetCursorPosition(12,14);
            Console.Write("Procure um time gaucho: ");
            this.nome = Console.ReadLine();
            if (this.nome == "") break;

            //procura no banco de dados se existe o nome da time informado
            this.posicao = 0;

            bool achou = false;
            foreach (var Time in bancoDadosRS)
            {
                if (this.nome == Time.nomePO){
                    achou = true;

                    break;
                }
                this.posicao++;
            }

            //mostra os dados do time, caso tenha encontrado ou mostra a mensagem de time não encontrado
            if (achou){
                // achou o time e vai mostrar os dados
                this.mostrarDadosRS();

            }else{
                // não achou a porcaria do time, mostra a mensagem
                string resp = this.tela.perguntar(12,17, "Time não existente no sistema bichão. Deve ser de outro estado. ");
                this.posicao = 0;
            }
        }
    }

    public void montarTelaPO(){
        Console.SetCursorPosition(11,9);
        Console.Write("Clube          : ");
        Console.SetCursorPosition(11,10);
        Console.Write("Tit. Nacionais : ");
        Console.SetCursorPosition(11,11);
        Console.Write("Tit. Estaduais : ");
        Console.SetCursorPosition(11,12);
        Console.Write("Estado         : ");
        detEstado();
    }

    public void mostrarDadosPO(){
        Console.SetCursorPosition(27,9);
        Console.Write(this.bancoDadosPO[this.posicao].nomePO);
        Console.SetCursorPosition(27,10);
        Console.Write(this.bancoDadosPO[this.posicao].titNacionalPO);
        Console.SetCursorPosition(27,11);
        Console.Write(this.bancoDadosPO[this.posicao].titEstadualPO);
        Console.SetCursorPosition(27,12);
        Console.Write(this.bancoDadosPO[this.posicao].estadoPO);
    }

    public void mostrarDadosSC(){
        Console.SetCursorPosition(27,9);
        Console.Write(this.bancoDadosSC[this.posicao].nomePO);
        Console.SetCursorPosition(27,10);
        Console.Write(this.bancoDadosSC[this.posicao].titNacionalPO);
        Console.SetCursorPosition(27,11);
        Console.Write(this.bancoDadosSC[this.posicao].titEstadualPO);
        Console.SetCursorPosition(27,12);
        Console.Write(this.bancoDadosSC[this.posicao].estadoPO);
    }

    public void mostrarDadosRS(){
        Console.SetCursorPosition(27,9);
        Console.Write(this.bancoDadosRS[this.posicao].nomePO);
        Console.SetCursorPosition(27,10);
        Console.Write(this.bancoDadosRS[this.posicao].titNacionalPO);
        Console.SetCursorPosition(27,11);
        Console.Write(this.bancoDadosRS[this.posicao].titEstadualPO);
        Console.SetCursorPosition(27,12);
        Console.Write(this.bancoDadosRS[this.posicao].estadoPO);
    }

    public void detEstado(){
        foreach (var Time in bancoDadosPO){
            if (Time.estadoPO == "SC"){
                bancoDadosSC.Add (Time);
            } else if (Time.estadoPO == "RS"){
                bancoDadosRS.Add (Time);
            }
        }
    }
}