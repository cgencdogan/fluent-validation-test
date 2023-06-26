using FluentValidation;

namespace FluentValidationTest.Models
{
    public class TaskItem
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool RemindMe { get; set; }
        public int? ReminderMinutesBeforeDue { get; set; }
        public List<string> SubItems { get; set; }
    }

    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.DueDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("DueDate bugünden sonraki bir tarih olmalı");

            When(x => x.RemindMe == true, () =>
            {
                RuleFor(x => x.ReminderMinutesBeforeDue)
                .NotNull()
                .WithMessage("ReminderMinutesBeforeDue belirtilmeli")
                .GreaterThan(0)
                .WithMessage("ReminderMinutesBeforeDue 0'dan büyük olmalı")
                .Must(value => value % 10 == 0)
                .WithMessage("ReminderMinutesBeforeDue 10 veya 10'un katları olmalı");
            });

            RuleForEach(x => x.SubItems)
                .NotEmpty()
                .WithMessage("SubItems değeri boş olamaz");
        }

    }
}
