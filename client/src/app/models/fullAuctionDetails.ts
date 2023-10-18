export interface fullAuctionDetails {
    auctioneerId: number
    productId: number
    product: Product
    region: string
    auctionDetails: string
    auctionStartDate: string
    formattedAuctionStartDate: string
    auctionActive: boolean
    category: string
    hostName: string
    auctionParticipants: []
    messages: []
    bids: []
  }

  export interface Product {
    id: number
    name: string
    price: number
    image: string
    description: string
    quantity: number
    photos: Photo[]
    ownerId: number
    ownerName: string
  }

  export interface Photo {
    id: number
    url: string
    referenceId: number
  }
