package com.levente.kovacs.finalprojectapplication

import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import java.text.DecimalFormat

class SensorActivity : AppCompatActivity(), SensorEventListener {

    private lateinit var textViewX: TextView
    // private lateinit var textViewY: TextView
    // private lateinit var textViewZ: TextView

    private lateinit var sensorManager: SensorManager
    private var temperatureSensor: Sensor? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.sensor_activity)

        textViewX = findViewById(R.id.textViewX)
        // textViewY = findViewById(R.id.textViewY)
        // textViewZ = findViewById(R.id.textViewZ)

        sensorManager = getSystemService(SENSOR_SERVICE) as SensorManager
        temperatureSensor = sensorManager.getDefaultSensor(Sensor.TYPE_AMBIENT_TEMPERATURE)

        if (temperatureSensor == null) {
            textViewX.text = "Sensor inaccessible"
        }
    }

    override fun onResume() {
        super.onResume()
        temperatureSensor?.also { sensor ->
            sensorManager.registerListener(this, sensor, SensorManager.SENSOR_DELAY_NORMAL)
        }
    }

    override fun onPause() {
        super.onPause()
        sensorManager.unregisterListener(this)
    }

    override fun onSensorChanged(event: SensorEvent?) {
        val decimalFormat = DecimalFormat("#.##")
        event?.let {
            textViewX.text = "Temperature: ${decimalFormat.format(it.values[0])} °C"
            // textViewY.text = "Y: "
            // textViewZ.text = "Z: "
        }
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {

    }
}