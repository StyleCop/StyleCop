namespace Mediplus.Barcoding
{
    using System;

    /// <summary>Product information structure.</summary>
    [Serializable]
    public struct Product
    {
        /// <summary>The product identifier.</summary>
        private readonly short productId;

        /// <summary>The batch identifier.</summary>
        private readonly short batchId;

        /// <summary>The serial number.</summary>
        private readonly int serialNumber;

        /// <summary>The validation hash.</summary>
        private byte[] hash;

        /// <summary>Initializes a new instance of the ProductInformation struct.</summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="batchId">The batch identifier.</param>
        /// <param name="serialNumber">The serial number.</param>
        public Product(short productId, short batchId, int serialNumber)
        {
            this.productId = productId;
            this.batchId = batchId;
            this.serialNumber = serialNumber;
            this.hash = default(byte[]);
        }

        /// <summary>Initializes a new instance of the ProductInformation struct.</summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="batchId">The batch identifier.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="hash">The validation hash.</param>
        public Product(short productId, short batchId, int serialNumber, byte[] hash)
        {
            this.productId = productId;
            this.batchId = batchId;
            this.serialNumber = serialNumber;
            this.hash = hash;
        }

        /// <summary>Gets the batch identifier.</summary>
        /// <value>The batch identifier.</value>
        public short BatchId
        {
            get { return this.batchId; }
        }

        /// <summary>Gets the product identifier.</summary>
        /// <value>The product identifier.</value>
        public short ProductId
        {
            get { return this.productId; }
        }

        /// <summary>Gets the serial number.</summary>
        /// <value>The serial number.</value>
        public int SerialNumber
        {
            get { return this.serialNumber; }
        }

        /// <summary>Gets the validation hash.</summary>
        /// <value>The validation hash.</value>
        public byte[] Hash
        {
            get { return this.hash; }
            internal set { this.hash = value; }
        }
    }
}