const mongoose = require('mongoose');
const MeaningSchema = new mongoose.Schema({
    text: { type: String, required: true }
});
module.exports = mongoose.model('Meaning', MeaningSchema);
