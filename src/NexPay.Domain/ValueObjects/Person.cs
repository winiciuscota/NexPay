namespace NexPay.Domain.ValueObjects
{
    public class Person
    {
        /// <summary>
        /// Name of the company
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Name of the bank
        /// </summary>
        /// <value></value>
        public string Bank { get; set; }

        /// <summary>
        /// Agency code
        /// </summary>
        /// <value></value>
        public string Agency { get; set; }

        /// <summary>
        /// Account code
        /// </summary>
        /// <value></value>
        public string Account { get; set; }
    }
}