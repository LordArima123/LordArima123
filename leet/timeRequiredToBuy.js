var timeRequiredToBuy = function(tickets, k) {
    let k_tickets = tickets[k];
    let res = 0;
    for (let i = 0; i <tickets.length; i++) {
        if ( tickets[i] < k_tickets){
            res += tickets[i];
        } else if ( i <= k){
            res += k_tickets;
        } else {
            res += k_tickets-1
        }
    }
    return res;
};

let tickets = [15,66,3,47,71,27,54,43,97,34,94,33,54,26,15,52,20,71,88,42,50,6,66,88,36,99,27,82,7,72];
let k = 18;
console.log(timeRequiredToBuy(tickets, k));