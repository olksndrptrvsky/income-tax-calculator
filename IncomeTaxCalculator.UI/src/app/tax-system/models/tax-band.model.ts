export class TaxBandModel {
    constructor(
        public lowerLimit: number,
        public upperLimit: number | null,
        public rate: number,
    ) { }
}
