using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVideoClips
{
    public partial class FormManual : Form
    {
        public FormManual()
        {
            InitializeComponent();
            InitializeManualContent();
        }

        private void InitializeManualContent()
        {
            this.Text = "Руководство по использованию";
            this.ClientSize = new System.Drawing.Size(700, 520);
            var tb = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            tb.Text =
@"Краткое руководство по работе с программой 'Каталог видеоклипов':

1) Открытие файла
- Нажмите 'Выбрать файл' и укажите CSV с названием 'DataSet.csv' или любым другим файлом CSV. Программа попытается прочитать кодировку CP1251, а затем UTF-8.

2) Просмотр данных
- Данные отображаются в таблице. Первая строка считается заголовком столбцов.

3) Фильтрация
- Введите значение для фильтра в поле справа внизу и выберите пункт 'Фильтр' → нужный столбец. Пункт 'Сбросить фильтр' вернёт видимость всех строк.
- Также есть общая кнопка фильтра, которая применяет поиск по всем столбцам.

4) Поиск
- Введите текст в поле 'Поиск' и нажмите 'Поиск' — строки, содержащие текст, будут выделены.

5) Сортировка
- В меню вверху справа доступны сортировки по возрастанию и по убыванию для некоторых колонок (ID, Вес, Длительность). Программа умеет корректно распознавать числа и времена (например, 00:02:30).

6) Сохранение
- Нажмите 'Сохранить файл' и выберите место — таблица будет сохранена в CSV с разделителем ;

7) Графики
- Нажмите 'График' — откроется окно построения графиков. Выберите столбец и операцию (Количество, Сумма, Среднее, Сортировка).

8) Дополнительно
- Правая кнопка мыши на строке таблицы позволяет скопировать её в буфер обмена.
- Иконки в верхней панели используют набор FontAwesome.Sharp.

Если нужно добавить поддержку других форматов или экспорт в Excel — напишите, добавлю.";

            this.Controls.Add(tb);
        }
    }
}
