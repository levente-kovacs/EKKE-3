const Flower = require('../models/Flower');
const Meaning = require('../models/Meaning');

exports.getAllFlowers = async (req, res) => {
  try {
    const flowers = await Flower.find().populate('meanings');
    res.json(flowers);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
};

exports.getFlowerById = async (req, res) => {
  // console.log(req.params.id);
  try {
    const flower = await Flower.findById(req.params.id).populate('meanings');
    if (!flower) return res.status(404).json({ message: 'Flower not found' });
    res.json(flower);
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
};

exports.createFlower = async (req, res) => {
  try {
    const flower = new Flower(req.body);
    await flower.save();
    res.status(201).json(flower);
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
};

exports.updateFlower = async (req, res) => {
  try {
    const flower = await Flower.findByIdAndUpdate(req.params.id, req.body, { new: true });
    if (!flower) return res.status(404).json({ message: 'Flower not found' });
    res.json(flower);
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
};

exports.deleteFlower = async (req, res) => {
  try {
    const flower = await Flower.findByIdAndDelete(req.params.id);
    if (!flower) return res.status(404).json({ message: 'Flower not found' });
    res.json({ message: 'Flower deleted' });
  } catch (error) {
    res.status(500).json({ message: error.message });
  }
};

exports.searchFlowersByName = async (req, res) => {
    const { word } = req.params;
  
    try {
      const flowers = await Flower.find({ name: { $regex: word, $options: 'i' } });
      res.json(flowers);
    } catch (error) {
      res.status(500).json({ message: error.message });
    }
};

exports.getFlowersForSummerAutumn = async (req, res) => {
    try {
      const flowers = await Flower.find({
        month: { $gte: 6, $lte: 11 }
      }).sort({ month: 1 });
  
      const result = flowers.map(flower => ({
        month: flower.month,
        name: flower.name
      }));
  
      res.json(result);
    } catch (error) {
      res.status(500).json({ message: error.message });
    }
};

exports.getMostCommonMeaning = async (req, res) => {
    try {
      const flowers = await Flower.find().populate('meanings');
  
      const meaningCount = {};
      flowers.forEach(flower => {
        flower.meanings.forEach(meaning => {
          meaningCount[meaning.text] = (meaningCount[meaning.text] || 0) + 1;
        });
      });
  
      const mostCommonMeaning = Object.entries(meaningCount).reduce(
        (max, curr) => (curr[1] > max[1] ? curr : max),
        ['', 0]
      );
  
      res.json({ meaning: mostCommonMeaning[0], count: mostCommonMeaning[1] });
    } catch (error) {
      res.status(500).json({ message: error.message });
    }
};
