# Sistema de Segurança de Baixo Custo
Repositório do Projeto do Sistema de Segurança de Baixo Custo desenvolvido para a disciplina de Projetos do curso de Engenharia de Computação da UNIFESP.

O projeto integra um Arduino UNO, uma câmera VGA 0v7660 com um algoritmo de processamento de Imagens através do Algoritmo HOG (Historgrama de Gradiante Orientado) utilizando a biblioteca OpenCV em Python. Dessa forma, conseguimos identificar através de uma imagem se temos a presença de uma silhueta humana e então emitir alertas de segurança.

Para isso, foi criado um software em VB que realiza a leitura e interpretação dos dados da imagem capturada pela câmera conectada ao Arduino através da porta serial. As imagens capturadas são armazenadas e analizadas pelo script em Python criado através da biblioteca Open CV. Os códigos e o esquema elétrico estão disponíveis no repositório.
