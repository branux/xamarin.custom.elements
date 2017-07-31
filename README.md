# Xamarin Custom Elemts
O projeto atualmente só foi testado no Android.

## Custom Dialog

Para utilizar o dialog o objeto contem o Dialog deve ser um Absolute Layout;

Atenção algumas dicas:
> - Caso os Filhos sejam de tipo diferentes após esconder o dialog você deve chamar o Destroy, como acontece no exemplo;
> - Se for sempre o mesmo elemento, como por exemplo um loading é só esconder;
