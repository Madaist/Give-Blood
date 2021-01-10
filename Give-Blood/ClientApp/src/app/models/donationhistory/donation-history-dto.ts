export class DonationHistoryDTO {
  qrCode: string;
  date: string;
  type: string;

  constructor(qrCode?: string, date?: string, type?: string) {
    this.qrCode = qrCode;
    this.date = date;
    this.type = type;
  }
}
