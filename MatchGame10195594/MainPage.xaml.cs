namespace MatchGame10195594
{
    public partial class MainPage : ContentPage
    {
        //Declaramos una variable de tiempo con la interfaz de DispatcherTimer
        IDispatcherTimer timer;
        //Declaramos una variable entera para los milisegundo
        int milisegundos; 
        //Declaramos una variable entera para los pares de la tarjetas
        int parejas; 


        public MainPage()
        {
            //Definimos el valor de la variable del tiempo (timer)
            timer = Dispatcher.CreateTimer(); 
            InitializeComponent();
            //El intervalo de tiempo sera igual al segundo iniciado con .1
            timer.Interval = TimeSpan.FromSeconds(.1); 
            //Definimos el método tiempo a la variable timer
            timer.Tick += Timer_Tick;  
            //Método que muestra los emoji e inicia el juego
            SetUpGame();
        }

        //Creamos el método para lo del tiempo mediante una condición
        private void Timer_Tick(object? sender, EventArgs e) 
        {
            //La variable incrementa en uno
            milisegundos++;
            //El label del tiempo ira mostrando los segundos que se tarda en terminar el juego
            Tiempo.Text = (milisegundos / 10F).ToString("0.0s"); 
            //Si los pares de tarjetas son igual a 8 dara inicio al if
            if (parejas == 8) 
            {
                //Cuando los pares de tarjetas llego o sea igual a 8 el tiempo de detendra
                timer.Stop();  
                //Cuando el tiempo se detenga dara un mensaje en el label
                Tiempo.Text = Tiempo.Text + " - Jugar otra vez?"; 
                //De tal manera que el botón se ara visible para poder reiniciar el juego 
                Reinicio.IsVisible = true; 
            }
        }

        //Creamos el método para dar inicio al juego 
        private void SetUpGame() 
        {
            //Lista de los pares de tarjeras que seran mostrados en el juego 
            List<string> animalEmoji = new List<string>() 
            {
                "🔯","🔯",
                "☪️","☪️",
                "💮","💮",
                "🔱","🔱",
                "💠","💠",
                "🕔","🕔",
                "🌔","🌔",
                "🎁","🎁",

            };
            //Instanciamos la clase random
            Random random = new Random(); 

            //Para cada botón del grid
            foreach (Button view in Grid1.Children) 
            {
                //El botón se hace visible 
                view.IsVisible = true; 
                //Declaramos una varibale entera donde se guardara un número al azar que equivale a la posicion de un emoji
                int index = random.Next(animalEmoji.Count); 
                //Declaramos una variable de cadena en donde se guarda un emoji de la lista que se seleccione con la variable index
                string nextEmoji = animalEmoji[index]; 
                //El boton equivaldrá a la varible nextEmoji
                view.Text = nextEmoji; 
                //Se elimina el emoji seleccionado de la lista
                animalEmoji.RemoveAt(index); 
            }
            //El tiempo se reinicia
            timer.Start(); 
            //Los milisegundos se receteen
            milisegundos = 0; 
            //Los pares de tarjeta emojis se recetan
            parejas = 0; 
        }

        //Se guarda en la variable el último boton cliqueado
        Button ultimoButtonClicked; 
        //Declaramos una varible booleana para guardar la accion de encontrar pares de tarjeta
        bool encontrandoMatch = false;

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Se guarda la información del botón cliqueado
            Button button = ((Button)sender); 
            //Si encontrando match es falso
            if (encontrandoMatch == false) 
            {
                //El botón encontrado se hace visible
                button.IsVisible = false;  
                //Guardamos este boton en la varible
                ultimoButtonClicked = button;  
                //Se vuelve verdadero
                encontrandoMatch = true;  
            }
            //Si el botón cliqueado coicide con el botón guardado
            else if (button.Text == ultimoButtonClicked.Text) 
            {
                //El par de tarjeras incrementa en uno
                parejas++;  
                //Se hace visible el último botón cliqueado
                button.IsVisible = false;  
                //Y este se vuelve falso
                encontrandoMatch = false; 
            }
            else
            {
                //El botón guardado se vuelve visible
                ultimoButtonClicked.IsVisible = true;
                //Mientras que el otro se vuelve falso
                encontrandoMatch = false;  
            }
        }
        private void Reinicio_Clicked(object sender, EventArgs e)
        {
            //Si los pares de tarjetas son igual al 8 dara inicio al if
            if (parejas == 8)  
            {
                //Metodo que muestra las tarjetas y da inicio al juego
                SetUpGame();  
                //El boton se reinicio se vuelve invisible cada que el juego inicie
                Reinicio.IsVisible = false;  
            }
        }

    }

}
