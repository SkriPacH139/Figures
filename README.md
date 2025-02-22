# Описание проекта
Данное WPF-приложение позволяет вычислять площади различных геометрических фигур (прямоугольник, круг, треугольник). Программа включает проверку корректности ввода данных и обработку возможных ошибок.

## Методы отладки в Microsoft Visual Studio
В процессе разработки и тестирования использовались следующие способы отладки:
 -Точки останова (Breakpoints)
  Устанавливались в ключевых местах кода для пошагового анализа выполнения программы.
  Использовались для проверки вычислений площади фигур.
  Стек вызовов (Call Stack)

## Позволил отслеживать последовательность вызовов методов и выявлять возможные ошибки.
Проверка корректного перехода между обработчиками событий.
 -Окно переменных (Locals, Autos, Watch)
  Анализ значений переменных в реальном времени при выполнении программы.
  Использовалось для проверки корректности вычислений по формуле Герона.
  Обработчики исключений (Exception Handling)

## Проверка и отладка обработки ошибок при вводе некорректных данных.
Реализация механизмов защиты от ошибок при вводе буквенных символов вместо чисел.
  -Трассировка (Debug Output, Trace.WriteLine)
  Вывод отладочных сообщений в Output Window для контроля хода выполнения программы.
  Использовалась для тестирования работы обработчиков событий и валидации данных.
  
## Результаты отладки
В ходе тестирования ошибок выявлено не было. Программа корректно обрабатывает вводимые данные и исключает возможность выполнения вычислений при некорректном вводе.

![Основное окно]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/1.png))
![Выбран прямоугольник]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/2.png))
![Выбран круг]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/3.png))
![Выбран треугольник]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/4.png))
![Расчет площади прямоугольника]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/5.png))
![Расчет площади круга]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/6.png))
![Ошибка треугольник]([screenshots/screenshot1.pn](https://github.com/SkriPacH139/Figures/blob/master/7.png))
![Расчет площади треугольника]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/8.png))
![Ошибка прямоугльник]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/9.png))
![Ошибка круг]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/10.png))
![Шибка выбора фигур]([screenshots/screenshot1.png](https://github.com/SkriPacH139/Figures/blob/master/11.png))
