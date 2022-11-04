Tela tela = new Tela();
Controle controle = new Controle(tela);

string opcao;
List<string> menuPrincipal = new List<string>();

menuPrincipal.Add("1 - Clubes de Santa Catarina      ");
menuPrincipal.Add("2 - Clubes do Rio Grande do Sul   ");
menuPrincipal.Add("3 - Clubes de todos os estados    ");
menuPrincipal.Add("0 - Sair                          ");

tela.configurarTela();
 
while(true){
    tela.montarTelaSistema();
    opcao = tela.mostrarMenu(menuPrincipal,5,5);

    if (opcao == "0") break;
    if (opcao == "1") {
        controle.executarCRUDSC();
    }
    if (opcao == "2") {
        controle.executarCRUDRS();
    } 
    if (opcao == "3") {
        controle.executarCRUD();
    }

}

Console.ReadKey();
