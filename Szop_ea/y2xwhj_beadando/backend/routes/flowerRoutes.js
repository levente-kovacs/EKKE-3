const express = require('express');
const router = express.Router();
const flowerController = require('../controllers/flowerController');
const { authenticate } = require('../middlewares/auth');
const swaggerUi = require('swagger-ui-express');
const YAML = require('yamljs');
const swaggerDocument = YAML.load('./docs/swagger.yaml');

router.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));
router.get('/', flowerController.getAllFlowers);
router.get('/:id', flowerController.getFlowerById);
router.post('/', authenticate, flowerController.createFlower);
router.put('/:id', authenticate, flowerController.updateFlower);
router.delete('/:id', authenticate, flowerController.deleteFlower);
router.get('/search/:word', flowerController.searchFlowersByName);
router.get('/spec/summer-autumn', flowerController.getFlowersForSummerAutumn);
router.get('/spec/most-common-meaning', flowerController.getMostCommonMeaning);

module.exports = router;
