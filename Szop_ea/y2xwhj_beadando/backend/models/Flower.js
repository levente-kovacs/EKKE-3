const mongoose = require('mongoose');
const FlowerSchema = new mongoose.Schema({
    _id: mongoose.Schema.Types.ObjectId,
    name: { type: String, required: true },
    anniversary: { type: String, required: true },
    month: { type: Number, required: true },
    when: { type: String, required: true },
    meanings: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Meaning' }]
});
module.exports = mongoose.model('Flower', FlowerSchema);
